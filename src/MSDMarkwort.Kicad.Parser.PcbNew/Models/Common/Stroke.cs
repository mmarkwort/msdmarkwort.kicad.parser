using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class Stroke
    {
        [KicadElement("width")]
        public double Width { get; set; }

        [KicadElement("type")]
        public string Type { get; set; }
    }
}
