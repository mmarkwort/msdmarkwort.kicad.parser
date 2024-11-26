# KICAD File Parser (.NET 8.0 based)

Simple .NET based parser for KICAD files. Currently supported formats are:

- pcbnew
- kicad_mod
- fp-lib-table
- eeschema
- kicad_sym
- sym-lib-table

## How to use

### Eeschema

Add nuget package to your project:

`
dotnet add package MSDMarkwort.Kicad.Parser.EESchema
`

or via Visual Studio Package Manager.

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

#### Symbol libary & symbols

With the Eeschema library it is also possible to load the symbol library table file and symbol files.

```
var parser = new SymLibTableParser();
var parserResult = parser.Parse("sym-lib-table");

if(parser.Success)
{
    var symLib = parser.Result;
    var version = symLib.Version;
    
   //... 
}
```

```
var parser = new SymLibParser();
var parserResult = parser.Parse("mysymbol.kicad_sym");

if(parser.Success)
{
    var symbol = parser.Result;
    var version = symbol.Version;
    
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

#### Footprint libary & footprints

With the Pcbnew library it is also possible to load the fottprint library table file and footprint files.

```
var parser = new FootprintLibTableParser();
var parserResult = parser.Parse("fp-lib-table");

if(parser.Success)
{
    var footprintLib = parser.Result;
    var version = footprintLib.Version;
    
   //... 
}
```

```
var parser = new FootprintLibParser();
var parserResult = parser.Parse("mysymbol.kicad_mod");

if(parser.Success)
{
    var footprint = parser.Result;
    var version = footprint.Version;
    
   //... 
}
```

## FAQ

### The parser result property `Success` is false

In this case parsing was not successful. May be due to a bug in this libray or an unsupported file.

### What is the minimum version of Kicad files that can be parsed?

Minimum file version of `kicad_sch`, `kicad_pcb`, `kicad_sym` & `kicad_mod` is `20200829` which should be Kicad 6.0.

### What does the `Warning` property of the parser result mean?

A warning is generated if,
- a property is missing
- a property has the wrong type.
- file version is too old

Any warning except the version warning is interesstant to me. Please let me know.

### Will Kicad legacy versions be supported?

No.

### Will there be writers in the future

Yes.

### Are enums currently supported?

No, but that is planned.

### Can the libary parse the `kicad_pro` format

No, but in future.
