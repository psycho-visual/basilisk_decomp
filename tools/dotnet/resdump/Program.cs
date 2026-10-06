// Dump a binary .resources file: one line per entry (name, type, value) plus raw byte[] blobs to a directory.
using System.Resources;
using System.Text;

var path = args[0];
var outDir = args[1];
Directory.CreateDirectory(outDir);
using var rr = new ResourceReader(path);
var entries = new SortedDictionary<string, (string type, byte[] data)>(StringComparer.Ordinal);
var e = rr.GetEnumerator();
while (e.MoveNext())
{
    var name = (string)e.Key;
    rr.GetResourceData(name, out var type, out var data);
    entries[name] = (type, data);
}
using var tsv = new StreamWriter(Path.Combine(outDir, "entries.tsv"), false, new UTF8Encoding(false));
tsv.WriteLine("name\ttype\tvalue");
foreach (var (name, (type, data)) in entries)
{
    object v = null;
    try { v = rr.GetType(); } catch { }
    string val;
    switch (type)
    {
        case "ResourceTypeCode.String":
        {
            // 7-bit encoded length prefix then UTF-8
            int len = 0, shift = 0, i = 0; byte b;
            do { b = data[i++]; len |= (b & 0x7f) << shift; shift += 7; } while ((b & 0x80) != 0);
            val = Encoding.UTF8.GetString(data, i, len);
            break;
        }
        case "ResourceTypeCode.ByteArray":
        {
            int len = BitConverter.ToInt32(data, 0);
            var blob = data.AsSpan(4, len).ToArray();
            var file = Path.Combine(outDir, "blobs", name + ".bin");
            Directory.CreateDirectory(Path.GetDirectoryName(file));
            File.WriteAllBytes(file, blob);
            val = $"<byte[{len}] -> blobs/{name}.bin>";
            break;
        }
        case "ResourceTypeCode.Int32": val = BitConverter.ToInt32(data, 0).ToString(); break;
        case "ResourceTypeCode.Boolean": val = (data[0] != 0).ToString(); break;
        default: val = "<" + data.Length + " bytes: " + Convert.ToHexString(data.AsSpan(0, Math.Min(64, data.Length))) + ">"; break;
    }
    tsv.WriteLine($"{name}\t{type}\t{val.Replace("\\", "\\\\").Replace("\t", "\\t").Replace("\r", "\\r").Replace("\n", "\\n")}");
}
Console.WriteLine($"{entries.Count} entries");
