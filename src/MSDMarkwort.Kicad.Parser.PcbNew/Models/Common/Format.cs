using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class Format
    {
        [KicadElement("prefix")]
        public string Prefix { get; set; }

        [KicadElement("suffix")]
        public string Suffix { get; set; }

        [KicadElement("units")]
        public int Units { get; set; }

        [KicadElement("units_format")]
        public int UnitsFormat { get; set; }

        [KicadElement("precision")]
        public int Precision { get; set; }
    }
}
