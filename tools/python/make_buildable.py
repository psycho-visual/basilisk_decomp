"""Normalise the ILSpy-generated .csproj files under dotnet/ so the whole set builds with `dotnet build`
on any OS (no machine-specific HintPaths, sibling Razer assemblies as ProjectReferences, third-party
assemblies from NuGet, .NET Framework reference assemblies from NuGet via Directory.Build.props)."""
import re, sys, pathlib

root = pathlib.Path(sys.argv[1] if len(sys.argv) > 1 else 'dotnet')
projects = {p.stem: p for p in root.glob('*/*.csproj')}
nuget = {'log4net': ('log4net', '1.2.10'), 'Newtonsoft.Json': ('Newtonsoft.Json', '8.0.3')}
# CustomerFWU2Point5 embeds serialized WinForms resources; the SDK can only embed those via
# System.Resources.Extensions, which needs .NET Framework >= 4.6.2.
retarget = {'CustomerFWU2Point5': 'net462'}

for name, path in projects.items():
    s = path.read_text()
    s = s.replace('Sdk="Microsoft.NET.Sdk.WindowsDesktop"', 'Sdk="Microsoft.NET.Sdk"')
    winforms = '<UseWindowsForms>True</UseWindowsForms>' in s
    s = re.sub(r'\s*<UseWindowsForms>True</UseWindowsForms>', '', s)
    if name in retarget:
        s = re.sub(r'<TargetFramework>[^<]+</TargetFramework>', f'<TargetFramework>{retarget[name]}</TargetFramework>', s)
    refs = []
    def ref(m):
        inc = m.group(1)
        if inc in projects and inc != name:
            refs.append(f'    <ProjectReference Include="../{inc}/{inc}.csproj" />')
        elif inc in nuget:
            pkg, ver = nuget[inc]
            refs.append(f'    <PackageReference Include="{pkg}" Version="{ver}" />')
        else:
            refs.append(f'    <Reference Include="{inc}" />')
        return ''
    s = re.sub(r'\s*<Reference Include="([^"]+)">\s*<HintPath>[^<]*</HintPath>\s*</Reference>', ref, s)
    s = re.sub(r'\s*<Reference Include="([^"]+)"\s*/>', ref, s)
    # keep references written by an earlier run (makes the script idempotent)
    for m in re.finditer(r'\s*(<(?:Project|Package)Reference [^>]*/>)', s):
        refs.append('    ' + m.group(1))
    s = re.sub(r'\s*<(?:Project|Package)Reference [^>]*/>', '', s)
    if winforms:
        for fw in ('System', 'System.Drawing', 'System.Windows.Forms'):
            if f'<Reference Include="{fw}" />' not in refs:
                refs.append(f'    <Reference Include="{fw}" />')
    # CustomerFWU2Point5 also needs RcClientBase at compile time (base type of AutoServiceClient)
    if name == 'CustomerFWU2Point5' and 'RcClientBase' in projects:
        refs.append('    <ProjectReference Include="../RcClientBase/RcClientBase.csproj" />')
    refs = sorted(set(refs), key=lambda r: (('Project' not in r), ('Package' not in r), r))
    s = re.sub(r'\s*<ItemGroup>\s*</ItemGroup>', '', s)
    s = re.sub(r'\s*<ItemGroup\s*/>', '', s)
    s = s.replace('</Project>', '  <ItemGroup>\n' + '\n'.join(refs) + '\n  </ItemGroup>\n</Project>')
    path.write_text(s)
    print(f'{name}: {len(refs)} references')
