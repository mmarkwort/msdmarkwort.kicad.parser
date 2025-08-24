using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common.Enums;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Fill
    {
        [KicadParserSymbol("type")]
        public FillType Type { get; set; }

        [KicadParserComplexSymbol("color")]
        public Color Color { get; set; } = new Color();
    }
}
