using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common.Enums;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Stroke
    {
        [KicadParserSymbol("width")]
        public double Width { get; set; }

        [KicadParserSymbol("type")]
        public StrokeType Type { get; set; }

        [KicadParserComplexSymbol("color")]
        public Color Color { get; set; } = new Color();
    }
}
