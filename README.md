# KICAD File Parser (.NET based)

Simple .NET based parser for KICAD files. Currently supported format is:

- pcbnew since file version 20200829
- eeschema since file version 20200829

## How to use

### Eeschema

Add nuget package to your project:

`
dotnet add package MSDMarkwort.Kicad.Parser.EESchema
`

#### Example with file on disk

```
var parser = new EESchemaParser();
var parserResult = parser.Parse("myproject.kicad_sch");

if(parser.Success)
{
    var eeschema = parser.Result;
    var title = eeschema.TitleBlock.Title;
    
   //... 
}
```

#### Example using streams

```
var stream = new MemoryStream(...)
var parser = new PcbNewParser();
var parserResult = parser.Parse(stream);

if(parser.Success)
{
    var pcb = parser.Result;
    var title = eeschema.TitleBlock.Title;
    
   //... 
}
```

### Pcbnew

Add nuget package to your project:

`
dotnet add package MSDMarkwort.Kicad.Parser.PcbNew
`

#### Example with file on disk

```
var parser = new PcbNewParser();
var parserResult = parser.Parse("myproject.kicad_pcb");

if(parser.Success)
{
    var pcb = parser.Result;
    var title = pcb.TitleBlock.Title;
    
   //... 
}
```

#### Example using streams

```
var stream = new MemoryStream(...)
var parser = new PcbNewParser();
var parserResult = parser.Parse(stream);

if(parser.Success)
{
    var pcb = parser.Result;
    var title = pcb.TitleBlock.Title;
    
   //... 
}
```

## Limitations

- Enums currently treated as strings
- No writer yet
- Please note that some properties are still missing. If you identify one, please let me know