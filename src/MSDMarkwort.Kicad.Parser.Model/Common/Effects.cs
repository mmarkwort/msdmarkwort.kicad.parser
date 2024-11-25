using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Effects
    {
        [KicadParserComplexSymbol("font")]
        public Font Font { get; set; } = new Font();

        [KicadParserComplexSymbol("justify")]
        public Justify Justify { get; set; } = new Justify();

        [KicadParserSymbol("hide", parameterMappings: "hide")]
        public bool Hide { get; set; }

        [KicadParserSymbol("href")]
        public string Href { get; set; }
    }
}
