// Headless: decompile every function, write one C file + symbol/strings listings.
import ghidra.app.script.GhidraScript;
import ghidra.app.decompiler.*;
import ghidra.program.model.listing.*;
import ghidra.program.model.symbol.*;
import ghidra.program.model.address.*;
import ghidra.program.model.data.*;
import java.io.*;
import java.util.*;

public class ExportDecomp extends GhidraScript {
    @Override
    public void run() throws Exception {
        String[] args = getScriptArgs();
        File outDir = new File(args[0]);
        outDir.mkdirs();
        String base = currentProgram.getName().replaceAll("[^A-Za-z0-9_.-]", "_");

        DecompInterface ifc = new DecompInterface();
        DecompileOptions opts = new DecompileOptions();
        ifc.setOptions(opts);
        ifc.toggleCCode(true);
        ifc.toggleSyntaxTree(false);
        ifc.setSimplificationStyle("decompile");
        ifc.openProgram(currentProgram);

        Listing listing = currentProgram.getListing();
        FunctionManager fm = currentProgram.getFunctionManager();
        int n = 0, fail = 0;
        try (PrintWriter c = new PrintWriter(new BufferedWriter(new FileWriter(new File(outDir, base + ".c"))));
             PrintWriter idx = new PrintWriter(new BufferedWriter(new FileWriter(new File(outDir, base + ".functions.tsv"))))) {
            c.println("/*");
            c.println(" * Ghidra " + getGhidraVersion() + " decompilation of " + currentProgram.getName());
            c.println(" * Image base: " + currentProgram.getImageBase() + "  Language: " + currentProgram.getLanguageID());
            c.println(" * Compiler: " + currentProgram.getCompilerSpec().getCompilerSpecID());
            c.println(" */\n");
            c.println("#include \"" + base + ".h\"\n");
            idx.println("entry\tname\tsize\tthunk\texternal\tcalling_convention\tsignature");
            for (Function f : fm.getFunctions(true)) {
                if (monitor.isCancelled()) break;
                idx.println(f.getEntryPoint() + "\t" + f.getName(true) + "\t" + f.getBody().getNumAddresses() + "\t" +
                    f.isThunk() + "\t" + f.isExternal() + "\t" + f.getCallingConventionName() + "\t" + f.getPrototypeString(false, false));
                if (f.isExternal() || f.isThunk()) continue;
                DecompileResults r = ifc.decompileFunction(f, 120, monitor);
                c.println("/* ---------------------------------------------------------------------- */");
                c.println("/* " + f.getName(true) + " @ " + f.getEntryPoint() + " */\n");
                if (r != null && r.decompileCompleted() && r.getDecompiledFunction() != null) {
                    c.println(r.getDecompiledFunction().getC());
                } else {
                    fail++;
                    c.println("/* decompilation failed: " + (r == null ? "null" : r.getErrorMessage()) + " */\n");
                }
                n++;
                if (n % 200 == 0) println("decompiled " + n);
            }
        }
        println("functions decompiled: " + n + " failed: " + fail);

        // Data types header
        try (PrintWriter h = new PrintWriter(new BufferedWriter(new FileWriter(new File(outDir, base + ".h"))))) {
            ghidra.program.model.data.DataTypeWriter dtw = new ghidra.program.model.data.DataTypeWriter(currentProgram.getDataTypeManager(), h);
            List<DataType> list = new ArrayList<>();
            Iterator<DataType> it = currentProgram.getDataTypeManager().getAllDataTypes();
            while (it.hasNext()) {
                DataType dt = it.next();
                if (dt.getSourceArchive() == null || dt.getSourceArchive().getSourceArchiveID().equals(currentProgram.getDataTypeManager().getUniversalID()) ||
                    dt.getCategoryPath().toString().startsWith("/Demangler") || dt.getCategoryPath().toString().startsWith("/auto_structs") )
                    list.add(dt);
            }
            dtw.write(list, monitor);
        } catch (Exception e) { println("header write failed: " + e); }

        // Symbols: imports / exports
        try (PrintWriter s = new PrintWriter(new BufferedWriter(new FileWriter(new File(outDir, base + ".symbols.txt"))))) {
            SymbolTable st = currentProgram.getSymbolTable();
            s.println("== Exports / entry points ==");
            AddressIterator ai = st.getExternalEntryPointIterator();
            while (ai.hasNext()) {
                Address a = ai.next();
                Symbol sym = st.getPrimarySymbol(a);
                s.println(a + "\t" + (sym == null ? "?" : sym.getName(true)));
            }
            s.println("\n== Imports ==");
            for (Symbol sym : st.getExternalSymbols()) {
                ExternalLocation el = currentProgram.getExternalManager().getExternalLocation(sym);
                s.println((el == null ? "" : el.getLibraryName()) + "\t" + sym.getName());
            }
        }

        // Defined strings
        try (PrintWriter s = new PrintWriter(new BufferedWriter(new OutputStreamWriter(new FileOutputStream(new File(outDir, base + ".strings.tsv")), "UTF-8")))) {
            DataIterator di = listing.getDefinedData(true);
            while (di.hasNext()) {
                Data d = di.next();
                if (d.hasStringValue()) {
                    Object v = d.getValue();
                    String str = v == null ? "" : v.toString().replace("\\", "\\\\").replace("\n", "\\n").replace("\r", "\\r").replace("\t", "\\t");
                    s.println(d.getAddress() + "\t" + d.getDataType().getName() + "\t" + str);
                }
            }
        }
        ifc.dispose();
    }
}
