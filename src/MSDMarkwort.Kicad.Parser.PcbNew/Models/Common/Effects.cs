using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class Effects
    {
        [KicadElement("font")]
        public Font Font { get; set; } = new Font();

        [KicadElement("justify")]
        public Justify Justify { get; set; } = new Justify();
    }
}
