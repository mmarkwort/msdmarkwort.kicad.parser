using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol;

namespace MSDMarkwort.Kicad.Parser.EESchema.PartSymLib
{
    public class SymLib
    {
        [KicadParserSymbol("version")]
        public int Version { get; set; }

        [KicadParserSymbol("generator")]
        public string Generator { get; set; }

        [KicadParserSymbol("generator_version")]
        public string GeneratorVersion { get; set; }

        [KicadParserList("symbol", KicadParserListAddType.Complex)]
        public SymbolCollection Symbols { get; set; } = new SymbolCollection();
    }
}
