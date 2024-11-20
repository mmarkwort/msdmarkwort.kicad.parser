# KICAD File Parser (.NET based)

Simple .NET based parser for KICAD files. Currently supported format is:

- pcbnew since file version 20231014

## How to use

Add nuget package to your project:

`
dotnet add package MSDMarkwort.Kicad.Parser.PcbNew
`

### Example with file on disk

```
var parser = new PcbNewParser();
var parserResult = parser.Parse("myproject.kicad_pcb");

if(parser.Success)
{
    var pcb = parser.Result;
    var title = parser.TitleBlock.Title;
    
   //... 
}
```

### Example using streams

```
var stream = new MemoryStream(...)
var parser = new PcbNewParser();
var parserResult = parser.Parse(stream);

if(parser.Success)
{
    var pcb = parser.Result;
    var title = parser.TitleBlock.Title;
    
   //... 
}
```

## Limitations

- Enums currently treated as strings
- No writer yet
- Only pcbnew support yet

