using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Format
    {
        [KicadParameter(0)]
        public string SuppressZeroes { get; set; }

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

        [KicadParserSymbol("override_value")]
        public string OverrideValue { get; set; }
    }
}
