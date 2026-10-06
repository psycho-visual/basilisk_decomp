// Extract every embedded manifest resource from a .NET assembly. For .resources containers, also explode
// each entry: strings -> strings.tsv, byte[]/streams -> raw files, serialized objects (Bitmap/Icon) ->
// the embedded image payload found inside the BinaryFormatter blob.
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Resources;
using System.Text;

var asmPath = args[0];
var outDir = args[1];
Directory.CreateDirectory(outDir);
using var fs = File.OpenRead(asmPath);
using var pe = new PEReader(fs);
var md = pe.GetMetadataReader();
var corHdr = pe.PEHeaders.CorHeader;
var resDir = pe.GetSectionData(corHdr.ResourcesDirectory.RelativeVirtualAddress);
foreach (var h in md.ManifestResources)
{
    var r = md.GetManifestResource(h);
    if (!r.Implementation.IsNil) continue;
    var name = md.GetString(r.Name);
    unsafe
    {
        var p = resDir.Pointer + r.Offset;
        int len = *(int*)p;
        var bytes = new ReadOnlySpan<byte>(p + 4, len).ToArray();
        File.WriteAllBytes(Path.Combine(outDir, name), bytes);
        Console.WriteLine($"{name}\t{len}");
        if (name.EndsWith(".resources")) Explode(bytes, Path.Combine(outDir, name[..^10]));
    }
}

static void Explode(byte[] data, string dir)
{
    Directory.CreateDirectory(dir);
    using var rr = new ResourceReader(new MemoryStream(data));
    var tsv = new StringBuilder("name\ttype\tvalue\n");
    var e = rr.GetEnumerator();
    var names = new List<string>();
    while (e.MoveNext()) names.Add((string)e.Key);
    names.Sort(StringComparer.Ordinal);
    foreach (var name in names)
    {
        rr.GetResourceData(name, out var type, out var blob);
        string safe = string.Concat(name.Select(c => Path.GetInvalidFileNameChars().Contains(c) ? '_' : c));
        string val;
        if (type == "ResourceTypeCode.String")
        {
            int len = 0, shift = 0, i = 0; byte b;
            do { b = blob[i++]; len |= (b & 0x7f) << shift; shift += 7; } while ((b & 0x80) != 0);
            val = Encoding.UTF8.GetString(blob, i, len);
        }
        else if (type == "ResourceTypeCode.ByteArray" || type == "ResourceTypeCode.Stream")
        {
            int len = BitConverter.ToInt32(blob, 0);
            var raw = blob.AsSpan(4, len).ToArray();
            var ext = Sniff(raw, 0) ?? ".bin";
            File.WriteAllBytes(Path.Combine(dir, safe + ext), raw);
            val = $"<{len} bytes -> {safe}{ext}>";
        }
        else
        {
            // Serialized object (e.g. System.Drawing.Bitmap / Icon). Locate embedded image payload.
            var (off, ext) = FindImage(blob);
            if (off >= 0)
            {
                var img = blob.AsSpan(off).ToArray();
                if (ext == ".png") img = TrimPng(img);
                File.WriteAllBytes(Path.Combine(dir, safe + ext), img);
                val = $"<{type.Split(',')[0]} -> {safe}{ext}>";
            }
            else
            {
                File.WriteAllBytes(Path.Combine(dir, safe + ".serialized.bin"), blob);
                val = $"<{type.Split(',')[0]} {blob.Length} bytes -> {safe}.serialized.bin>";
            }
        }
        tsv.Append(name).Append('\t').Append(type.Split(',')[0]).Append('\t')
           .Append(val.Replace("\\", "\\\\").Replace("\t", "\\t").Replace("\r", "\\r").Replace("\n", "\\n")).Append('\n');
    }
    File.WriteAllText(Path.Combine(dir, "_entries.tsv"), tsv.ToString(), new UTF8Encoding(false));
}

static string Sniff(byte[] b, int o)
{
    if (b.Length - o < 4) return null;
    if (b[o] == 0x89 && b[o + 1] == 'P' && b[o + 2] == 'N' && b[o + 3] == 'G') return ".png";
    if (b[o] == 0xFF && b[o + 1] == 0xD8 && b[o + 2] == 0xFF) return ".jpg";
    if (b[o] == 'G' && b[o + 1] == 'I' && b[o + 2] == 'F' && b[o + 3] == '8') return ".gif";
    if (b[o] == 0 && b[o + 1] == 0 && b[o + 2] == 1 && b[o + 3] == 0) return ".ico";
    if (b[o] == 'B' && b[o + 1] == 'M') return ".bmp";
    return null;
}

static (int, string) FindImage(byte[] b)
{
    // BinaryFormatter blob: payload is the byte[] "Data" member near the end; scan for signatures.
    for (int i = 0; i < b.Length - 8; i++)
    {
        var s = Sniff(b, i);
        if (s == ".png" || s == ".jpg" || s == ".gif") return (i, s);
    }
    for (int i = 0; i < b.Length - 8; i++)
    {
        // ICO header: 00 00 01 00 count(LE16) followed by plausible entries
        if (b[i] == 0 && b[i + 1] == 0 && b[i + 2] == 1 && b[i + 3] == 0 && b[i + 4] > 0 && b[i + 4] < 32 && b[i + 5] == 0) return (i, ".ico");
        if (b[i] == 'B' && b[i + 1] == 'M' && BitConverter.ToInt32(b, i + 2) == b.Length - i - 1) return (i, ".bmp");
        if (b[i] == 'B' && b[i + 1] == 'M' && BitConverter.ToInt32(b, i + 2) <= b.Length - i && BitConverter.ToInt32(b, i + 2) > 54 && b[i + 6] == 0 && b[i + 7] == 0) return (i, ".bmp");
    }
    return (-1, null);
}

static byte[] TrimPng(byte[] b)
{
    int i = 8;
    while (i + 8 <= b.Length)
    {
        int len = (b[i] << 24) | (b[i + 1] << 16) | (b[i + 2] << 8) | b[i + 3];
        string t = Encoding.ASCII.GetString(b, i + 4, 4);
        i += 12 + len;
        if (t == "IEND") return b.AsSpan(0, Math.Min(i, b.Length)).ToArray();
    }
    return b;
}
