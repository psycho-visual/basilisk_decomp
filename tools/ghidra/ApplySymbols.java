// Apply a hand-curated symbol file (TSV: kind<TAB>address<TAB>name<TAB>comment) before export.
// kind = func | label | report (Razer 90-byte report struct) | bytes:N (byte array of N)
import ghidra.app.script.GhidraScript;
import ghidra.program.model.address.*;
import ghidra.program.model.data.*;
import ghidra.program.model.listing.*;
import ghidra.program.model.symbol.*;
import java.io.*;
import java.nio.file.*;

public class ApplySymbols extends GhidraScript {
    @Override
    public void run() throws Exception {
        DataTypeManager dtm = currentProgram.getDataTypeManager();
        StructureDataType rs = new StructureDataType(new CategoryPath("/razer"), "razer_report_t", 0);
        rs.add(ByteDataType.dataType, "status", "0x00 new, 0x01 busy, 0x02 ok, 0x03 fail, 0x04 timeout, 0x05 not supported");
        rs.add(ByteDataType.dataType, "transaction_id", null);
        rs.add(new ArrayDataType(ByteDataType.dataType, 2, 1), "remaining_packets", "big endian");
        rs.add(ByteDataType.dataType, "protocol_type", null);
        rs.add(ByteDataType.dataType, "data_size", null);
        rs.add(ByteDataType.dataType, "command_class", null);
        rs.add(ByteDataType.dataType, "command_id", "bit7 set = get/read");
        rs.add(new ArrayDataType(ByteDataType.dataType, 80, 1), "args", null);
        rs.add(ByteDataType.dataType, "crc", "XOR of bytes 2..87");
        rs.add(ByteDataType.dataType, "reserved", null);
        DataType report = dtm.addDataType(rs, DataTypeConflictHandler.REPLACE_HANDLER);

        SymbolTable st = currentProgram.getSymbolTable();
        Listing lst = currentProgram.getListing();
        int n = 0;
        for (String line : Files.readAllLines(Paths.get(getScriptArgs()[0]))) {
            if (line.isBlank() || line.startsWith("#")) continue;
            String[] f = line.split("\t", -1);
            String kind = f[0];
            Address a = toAddr(Long.decode(f[1]));
            String name = f[2];
            String cmt = f.length > 3 ? f[3] : "";
            if (kind.equals("func")) {
                Function fn = getFunctionAt(a);
                if (fn == null) { disassemble(a); fn = createFunction(a, name); }
                if (fn != null) {
                    fn.setName(name, SourceType.USER_DEFINED);
                    if (!cmt.isEmpty()) fn.setComment(cmt);
                } else println("could not create function at " + a);
            } else {
                Symbol s = st.getPrimarySymbol(a);
                if (s != null && s.getSource() != SourceType.DEFAULT) st.createLabel(a, name, SourceType.USER_DEFINED).setPrimary();
                else st.createLabel(a, name, SourceType.USER_DEFINED).setPrimary();
                DataType dt = null;
                if (kind.equals("report")) dt = report;
                else if (kind.startsWith("bytes:")) dt = new ArrayDataType(ByteDataType.dataType, Integer.parseInt(kind.substring(6)), 1);
                else if (kind.equals("dword")) dt = DWordDataType.dataType;
                if (dt != null) {
                    clearListing(a, a.add(dt.getLength() - 1));
                    lst.createData(a, dt);
                }
                if (!cmt.isEmpty()) lst.setComment(a, CodeUnit.PLATE_COMMENT, cmt);
            }
            n++;
        }
        println("applied " + n + " symbols");
    }
}
