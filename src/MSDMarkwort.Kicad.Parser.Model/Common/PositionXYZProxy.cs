using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class PositionXYZProxy
    {
        [KicadParserComplexSymbol("xyz")]
        public PositionXYZ PositionXYZ { get; set; } = new PositionXYZ();
    }
}
