using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class Font
    {
        [KicadElement("face")]
        public string FontFace { get; set; }

        [KicadElement("size")]
        public Size Size { get; set; } = new Size();

        [KicadElement("thickness")]
        public double Thickness { get; set; }

        [KicadElement("bold")]
        public bool Bold { get; set; }
    }
}
