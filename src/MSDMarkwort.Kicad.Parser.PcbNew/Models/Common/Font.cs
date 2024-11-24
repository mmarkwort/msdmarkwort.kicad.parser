using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class Font
    {
        [KicadParameter(0)]
        public string IsBold { get; set; }

        [KicadParserSymbol("face")]
        public string FontFace { get; set; }

        [KicadParserComplexSymbol("size")]
        public Size Size { get; set; } = new Size();

        [KicadParserSymbol("thickness")]
        public double Thickness { get; set; }

        [KicadParserSymbol("bold")]
        public bool Bold { get; set; }
    }
}
