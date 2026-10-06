using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
foreach (var a in args)
{
    using var fs = File.OpenRead(a);
    using var pe = new PEReader(fs);
    var md = pe.GetMetadataReader();
    var def = md.GetAssemblyDefinition();
    string tfm = "";
    foreach (var ch in def.GetCustomAttributes())
    {
        var ca = md.GetCustomAttribute(ch);
        if (ca.Constructor.Kind == HandleKind.MemberReference)
        {
            var mr = md.GetMemberReference((MemberReferenceHandle)ca.Constructor);
            var tr = md.GetTypeReference((TypeReferenceHandle)mr.Parent);
            if (md.GetString(tr.Name) == "TargetFrameworkAttribute")
            {
                var blob = md.GetBlobReader(ca.Value); blob.ReadUInt16(); tfm = blob.ReadSerializedString();
            }
        }
    }
    Console.WriteLine($"{Path.GetFileName(a)}\t{md.GetString(def.Name)} {def.Version}\t{tfm}\truntime={md.MetadataVersion}");
    foreach (var h in md.AssemblyReferences)
    {
        var r = md.GetAssemblyReference(h);
        Console.WriteLine($"    -> {md.GetString(r.Name)} {r.Version}");
    }
}
