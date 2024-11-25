using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class FilledPolygon
    {
        [KicadParserSymbol("layer")]
        public string Layer { get; set; }

        [KicadParserSymbol("island", KicadParserSymbolSetType.ImplicitBoolTrue)]
        public bool IsIsland { get; set; }

        [KicadParserComplexSymbol("pts")]
        public MultiPointPositionXY Pts { get; set; } = new MultiPointPositionXY();
    }
}
