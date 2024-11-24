using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class Format
    {
        [KicadParserSymbol("prefix")]
        public string Prefix { get; set; }

        [KicadParserSymbol("suffix")]
        public string Suffix { get; set; }

        [KicadParserSymbol("units")]
        public int Units { get; set; }

        [KicadParserSymbol("units_format")]
        public int UnitsFormat { get; set; }

        [KicadParserSymbol("precision")]
        public int Precision { get; set; }
    }
}
