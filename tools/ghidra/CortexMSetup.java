// Pre-analysis for a raw Cortex-M image: add RAM / peripheral / system blocks, walk the vector table,
// create + name handler functions, and set the Thumb TMode register on code.
import ghidra.app.script.GhidraScript;
import ghidra.program.model.address.*;
import ghidra.program.model.listing.*;
import ghidra.program.model.mem.*;
import ghidra.program.model.symbol.*;
import ghidra.program.model.data.*;
import ghidra.program.model.lang.*;
import java.math.BigInteger;

public class CortexMSetup extends GhidraScript {
    static final String[] SYS = {"__initial_sp","Reset_Handler","NMI_Handler","HardFault_Handler",
        "Reserved4","Reserved5","Reserved6","Reserved7","Reserved8","Reserved9","Reserved10","SVC_Handler",
        "Reserved12","Reserved13","PendSV_Handler","SysTick_Handler"};

    void block(String name, long start, long len, boolean exec, boolean vol) throws Exception {
        Memory mem = currentProgram.getMemory();
        Address a = toAddr(start);
        if (mem.getBlock(a) != null) return;
        MemoryBlock b = mem.createUninitializedBlock(name, a, len, false);
        b.setRead(true); b.setWrite(true); b.setExecute(exec); b.setVolatile(vol);
    }

    @Override
    public void run() throws Exception {
        String[] args = getScriptArgs();
        long ramBase = Long.decode(args.length > 0 ? args[0] : "0x04000000");
        long ramLen  = Long.decode(args.length > 1 ? args[1] : "0x8000");
        int nIrq     = Integer.decode(args.length > 2 ? args[2] : "32");
        if (args.length > 4) {
            // Initialised RAM contents recovered by replaying the scatter-load (RW data + ZI).
            java.io.File f = new java.io.File(args[4]);
            byte[] init = java.nio.file.Files.readAllBytes(f.toPath());
            MemoryBlock b = currentProgram.getMemory().createInitializedBlock("SRAM", toAddr(ramBase),
                new java.io.ByteArrayInputStream(init), init.length, monitor, false);
            b.setRead(true); b.setWrite(true); b.setExecute(false);
            b.setComment("RW/ZI data as initialised by __scatterload");
            if (ramLen > init.length) block("SRAM_FREE", ramBase + init.length, ramLen - init.length, false, false);
        } else {
            block("SRAM", ramBase, ramLen, true, false);
        }
        block("PERIPH", 0x40000000L, 0x00100000L, false, true);
        block("PERIPH_AHB", 0x50000000L, 0x00100000L, false, true);
        block("SCS", 0xE0000000L, 0x00100000L, false, true);

        MemoryBlock img = currentProgram.getMemory().getBlocks()[0];
        for (MemoryBlock mb : currentProgram.getMemory().getBlocks()) if (mb.getName().equals("FLASH_IMAGE")) { img = mb; break; }
        Address vt = img.getStart();
        img.setWrite(false); img.setExecute(true); img.setRead(true);
        // Keil/ARMCC __main lives right after the vector table; the HEX start record points at it.
        if (args.length > 3) {
            Address m = toAddr(Long.decode(args[3]) & ~1L);
            currentProgram.getSymbolTable().createLabel(m, "__main", SourceType.USER_DEFINED);
            currentProgram.getSymbolTable().addExternalEntryPoint(m);
        }
        currentProgram.getProgramContext().setValue(currentProgram.getRegister("TMode"), img.getStart(), img.getEnd(), BigInteger.ONE);
        SymbolTable st = currentProgram.getSymbolTable();
        Listing lst = currentProgram.getListing();
        Register tmode = currentProgram.getRegister("TMode");
        PointerDataType ptr = new PointerDataType();
        int total = 16 + nIrq;
        for (int i = 0; i < total; i++) {
            Address slot = vt.add(i * 4L);
            long v = currentProgram.getMemory().getInt(slot) & 0xffffffffL;
            String name = i < 16 ? SYS[i] : String.format("IRQ%d_Handler", i - 16);
            try { lst.createData(slot, i == 0 ? new DWordDataType() : ptr); } catch (Exception e) {}
            st.createLabel(slot, "vec_" + name, SourceType.USER_DEFINED);
            if (i == 0 || v == 0 || (v & 1) == 0) continue;
            Address tgt = toAddr(v & ~1L);
            if (!currentProgram.getMemory().contains(tgt)) continue;
            currentProgram.getProgramContext().setValue(tmode, tgt, tgt, BigInteger.ONE);
            Symbol existing = st.getPrimarySymbol(tgt);
            if (existing == null || existing.getSource() == SourceType.DEFAULT)
                st.createLabel(tgt, name, SourceType.USER_DEFINED);
            else
                st.createLabel(tgt, name, SourceType.USER_DEFINED); // secondary label (shared default handler)
            disassemble(tgt);
            if (getFunctionAt(tgt) == null) createFunction(tgt, null);
            st.addExternalEntryPoint(tgt);
        }
        // Whole flash image is Thumb code by default.
        Address lo = img.getStart();
        Address hi = img.getEnd();
        try { currentProgram.getProgramContext().setValue(tmode, lo, hi, BigInteger.ONE); } catch (Exception e) { }
        println("vector table processed: " + total + " entries");
    }
}
