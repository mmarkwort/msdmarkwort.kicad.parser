using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class PositionProxy
    {
        [KicadParserComplexSymbol("xy")]
        public Position Position { get; set; } = new Position();
    }
}
