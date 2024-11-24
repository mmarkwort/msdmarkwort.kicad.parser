using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class Polygon : IPts
    {
        [KicadParserComplexSymbol("pts")]
        public MultiPointPositionXY Pts { get; set; } = new MultiPointPositionXY();
    }
}
