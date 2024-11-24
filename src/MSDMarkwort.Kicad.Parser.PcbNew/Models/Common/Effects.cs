using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class Effects
    {
        [KicadParserComplexSymbol("font")]
        public Font Font { get; set; } = new Font();

        [KicadParserComplexSymbol("justify")]
        public Justify Justify { get; set; } = new Justify();
    }
}
