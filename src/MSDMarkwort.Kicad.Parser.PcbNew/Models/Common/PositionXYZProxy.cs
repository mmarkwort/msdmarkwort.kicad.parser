using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class PositionXYZProxy
    {
        [KicadParserComplexSymbol("xyz")]
        public PositionXYZ PositionXYZ { get; set; } = new PositionXYZ();
    }
}
