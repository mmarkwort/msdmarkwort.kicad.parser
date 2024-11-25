using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Stroke
    {
        [KicadParserSymbol("width")]
        public double Width { get; set; }

        [KicadParserSymbol("type")]
        public string Type { get; set; }

        [KicadParserComplexSymbol("color")]
        public Color Color { get; set; } = new Color();
    }
}
