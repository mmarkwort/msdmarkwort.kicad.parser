using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartLibSymbols
{
    public class LibSymbols
    {
        [KicadParserList("symbol", KicadParserListAddType.Complex)]
        public SymbolCollection Symbols { get; set; } = new SymbolCollection();
    }
}
