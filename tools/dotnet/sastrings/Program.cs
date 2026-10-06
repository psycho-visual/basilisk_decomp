// Static SmartAssembly string-encoding remover (no code from the target assembly is executed).
//  1. Reads the "{guid}" string blob resource, DES key/IV and offset straight from the target's IL.
//  2. Unpacks it with a port of SmartAssembly.Zip.SimpleZip.Unzip ('{z}' container, raw deflate, DES-CBC).
//  3. Rewrites   ldsfld GetString <field>; ldc.i4 N; callvirt GetString::Invoke   (HouseOfCards proxy)
//     and        ldc.i4 N; call SmartAssembly.StringsEncoding.Strings::Get        (direct)
//     into       ldstr "<decoded>"
//  4. Drops the injected CreateGetStringDelegate(typeof(T)) calls and GetString fields.
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

var inPath = args[0];
var outPath = args[1];
var resolver = new DefaultAssemblyResolver();
resolver.AddSearchDirectory(Path.GetDirectoryName(Path.GetFullPath(inPath)));
var asm = AssemblyDefinition.ReadAssembly(inPath, new ReaderParameters { AssemblyResolver = resolver, ReadingMode = ReadingMode.Immediate });
var mod = asm.MainModule;

var stringsType = mod.GetType("SmartAssembly.StringsEncoding.Strings") ?? throw new Exception("no SmartAssembly strings type");
var cctor = stringsType.Methods.First(m => m.IsConstructor && m.IsStatic);
var ldstrs = cctor.Body.Instructions.Where(i => i.OpCode == OpCodes.Ldstr).Select(i => (string)i.Operand).ToList();
// cctor assigns MustUseCache, OffsetValue, then opens the resource "{guid}"
int offset = int.Parse(ldstrs[1]); // MustUseCache = ldstrs[0], OffsetValue = ldstrs[1]
string resName = ldstrs.First(s => s.StartsWith("{") && s.EndsWith("}"));
var res = (EmbeddedResource)mod.Resources.First(r => r.Name == resName);

var unzip = mod.GetType("SmartAssembly.Zip.SimpleZip").Methods.First(m => m.Name == "Unzip");
var arrays = new List<byte[]>();
foreach (var ins in unzip.Body.Instructions)
    if (ins.OpCode == OpCodes.Ldtoken && ins.Operand is FieldDefinition fd && fd.InitialValue is { Length: 8 })
        arrays.Add(fd.InitialValue);
byte[] desKey = arrays.Count > 0 ? arrays[0] : null, desIv = arrays.Count > 1 ? arrays[1] : null;

byte[] blob = Unzip(res.GetResourceData());
Console.Error.WriteLine($"{mod.Name}: resource {resName} -> {blob.Length} bytes, offset {offset}, DES key {(desKey == null ? "-" : Convert.ToHexString(desKey))}");

string Get(int id)
{
    id -= offset;
    int idx = id, len;
    int b = blob[idx++];
    if ((b & 0x80) != 0)
        len = (b & 0x40) != 0 ? ((b & 0x1F) << 24) + (blob[idx++] << 16) + (blob[idx++] << 8) + blob[idx++] : ((b & 0x3F) << 8) + blob[idx++];
    else { len = b; if (len == 0) return string.Empty; }
    var raw = Convert.FromBase64String(Encoding.UTF8.GetString(blob, idx, len));
    return Encoding.UTF8.GetString(raw);
}

int replaced = 0, removedInit = 0;
var getStringFields = new HashSet<FieldDefinition>();
foreach (var type in AllTypes(mod.Types))
{
    foreach (var f in type.Fields)
        if (f.FieldType.FullName == "SmartAssembly.Delegates.GetString") getStringFields.Add(f);
    foreach (var m in type.Methods.Where(m => m.HasBody))
    {
        var il = m.Body.GetILProcessor();
        var ins = m.Body.Instructions;
        for (int i = 0; i < ins.Count; i++)
        {
            // proxy delegate: ldsfld GetString F ; ldc.i4 N ; callvirt Invoke
            if (ins[i].OpCode == OpCodes.Ldsfld && ins[i].Operand is FieldReference fr && fr.FieldType.FullName == "SmartAssembly.Delegates.GetString"
                && i + 2 < ins.Count && TryInt(ins[i + 1], out int n) && ins[i + 2].Operand is MethodReference inv && inv.Name == "Invoke")
            {
                int rid = (int)(fr.Resolve().MetadataToken.RID);
                string s = Get(n - rid);
                ins[i].OpCode = OpCodes.Ldstr; ins[i].Operand = s;
                ins[i + 1].OpCode = OpCodes.Nop; ins[i + 1].Operand = null;
                ins[i + 2].OpCode = OpCodes.Nop; ins[i + 2].Operand = null;
                replaced++;
            }
            // direct: ldc.i4 N ; call Strings::Get(int32)
            else if (TryInt(ins[i], out int n2) && i + 1 < ins.Count && ins[i + 1].OpCode == OpCodes.Call
                && ins[i + 1].Operand is MethodReference g && g.DeclaringType.FullName == "SmartAssembly.StringsEncoding.Strings" && g.Name == "Get")
            {
                ins[i].OpCode = OpCodes.Ldstr; ins[i].Operand = Get(n2);
                ins[i + 1].OpCode = OpCodes.Nop; ins[i + 1].Operand = null;
                replaced++;
            }
            // ldtoken T ; call GetTypeFromHandle ; call HouseOfCards.Strings::CreateGetStringDelegate
            else if (ins[i].OpCode == OpCodes.Ldtoken && i + 2 < ins.Count && ins[i + 2].Operand is MethodReference c
                && c.Name == "CreateGetStringDelegate")
            {
                for (int k = 0; k < 3; k++) { ins[i + k].OpCode = OpCodes.Nop; ins[i + k].Operand = null; }
                removedInit++;
            }
        }
        m.Body.Optimize();
    }
}
// GetString fields are now unreferenced; remove them (and any static ctor that became a bare 'ret').
foreach (var f in getStringFields) f.DeclaringType.Fields.Remove(f);
foreach (var type in AllTypes(mod.Types))
{
    var sc = type.Methods.FirstOrDefault(m => m.IsConstructor && m.IsStatic);
    if (sc != null && sc.Body.Instructions.All(x => x.OpCode == OpCodes.Nop || x.OpCode == OpCodes.Ret) && type.Name != "<Module>")
        type.Methods.Remove(sc);
}
Console.Error.WriteLine($"  decoded {replaced} string references, removed {removedInit} delegate initialisers, {getStringFields.Count} fields");

// 5. Strip the now-unused SmartAssembly runtime: SmartAssembly.* types, the control-character-named
//    helper types it injects, attributes pointing at them, and the encoded string blob resource.
static bool IsObfName(string s) => s.Any(ch => ch < 0x20);
var strip = AllTypes(mod.Types).Where(t => t.Namespace.StartsWith("SmartAssembly") || IsObfName(t.Namespace) || IsObfName(t.Name)).ToList();
var stripNames = new HashSet<string>(strip.Select(t => t.FullName));
bool Stripped(TypeReference t) => t != null && stripNames.Contains(t.GetElementType().FullName);
void CleanAttrs(ICustomAttributeProvider p)
{
    if (!p.HasCustomAttributes) return;
    foreach (var ca in p.CustomAttributes.Where(a => Stripped(a.AttributeType)).ToList()) p.CustomAttributes.Remove(ca);
}
CleanAttrs(asm); CleanAttrs(mod);
int dangling = 0;
foreach (var t in AllTypes(mod.Types).Where(t => !stripNames.Contains(t.FullName)))
{
    CleanAttrs(t);
    foreach (var m in t.Methods) { CleanAttrs(m); if (!m.HasBody) continue;
        foreach (var ins in m.Body.Instructions)
            if ((ins.Operand is MemberReference mr && (Stripped(mr.DeclaringType) || (mr is TypeReference tr && Stripped(tr)))))
            { dangling++; Console.Error.WriteLine($"  still referenced: {mr.FullName} in {m.FullName}"); } }
    foreach (var f in t.Fields) CleanAttrs(f);
    foreach (var pr in t.Properties) CleanAttrs(pr);
}
if (dangling == 0)
{
    foreach (var t in strip.Where(t => !t.IsNested)) mod.Types.Remove(t);
    mod.Resources.Remove(res);
    Console.Error.WriteLine($"  stripped {strip.Count} SmartAssembly runtime types and resource {resName}");
}
else Console.Error.WriteLine("  SmartAssembly runtime kept (still referenced)");
asm.Write(outPath);

// dump the full decoded string table too (useful for grepping)
var tablePath = Path.ChangeExtension(outPath, ".strings.tsv");
using (var w = new StreamWriter(tablePath, false, new UTF8Encoding(false)))
{
    int p = 0;
    while (p < blob.Length)
    {
        int start = p, len; int b = blob[p++];
        if ((b & 0x80) != 0) len = (b & 0x40) != 0 ? ((b & 0x1F) << 24) + (blob[p++] << 16) + (blob[p++] << 8) + blob[p++] : ((b & 0x3F) << 8) + blob[p++];
        else len = b;
        string s = len == 0 ? "" : Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(blob, p, len)));
        p += len;
        w.WriteLine($"{start + offset}\t{s.Replace("\\", "\\\\").Replace("\t", "\\t").Replace("\r", "\\r").Replace("\n", "\\n")}");
    }
}

static bool TryInt(Instruction i, out int v)
{
    v = 0;
    if (i.OpCode == OpCodes.Ldc_I4) { v = (int)i.Operand; return true; }
    if (i.OpCode == OpCodes.Ldc_I4_S) { v = (sbyte)i.Operand; return true; }
    if (i.OpCode.Code >= Code.Ldc_I4_0 && i.OpCode.Code <= Code.Ldc_I4_8) { v = i.OpCode.Code - Code.Ldc_I4_0; return true; }
    return false;
}

static IEnumerable<TypeDefinition> AllTypes(IEnumerable<TypeDefinition> ts)
{
    foreach (var t in ts) { yield return t; foreach (var n in AllTypes(t.NestedTypes)) yield return n; }
}

byte[] Unzip(byte[] buf)
{
    var r = new BinaryReader(new MemoryStream(buf));
    int magic = r.ReadInt32();
    if (magic == 0x04034b50) throw new NotSupportedException("PK container");
    int ver = magic >> 24;
    if ((magic & 0xFFFFFF) != 0x7D7A7B) throw new FormatException("Unknown Header");
    switch (ver)
    {
        case 1:
        {
            int total = r.ReadInt32();
            var outBuf = new byte[total];
            for (int pos = 0; pos < total;)
            {
                int clen = r.ReadInt32(), ulen = r.ReadInt32();
                var chunk = r.ReadBytes(clen);
                using var ds = new DeflateStream(new MemoryStream(chunk), CompressionMode.Decompress);
                int got = 0;
                while (got < ulen) { int k = ds.Read(outBuf, pos + got, ulen - got); if (k <= 0) break; got += k; }
                pos += ulen;
            }
            return outBuf;
        }
        case 2:
        {
            using var des = DES.Create();
            des.Key = desKey; des.IV = desIv;
            return Unzip(des.CreateDecryptor().TransformFinalBlock(buf, 4, buf.Length - 4));
        }
        case 3:
        {
            using var aes = Aes.Create();
            aes.Key = Enumerable.Repeat((byte)1, 16).ToArray(); aes.IV = Enumerable.Repeat((byte)2, 16).ToArray();
            return Unzip(aes.CreateDecryptor().TransformFinalBlock(buf, 4, buf.Length - 4));
        }
        default: throw new FormatException("version " + ver);
    }
}
