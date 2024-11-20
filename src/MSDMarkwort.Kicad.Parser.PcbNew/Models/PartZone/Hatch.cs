using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Hatch
    {
        [KicadParameter(0)]
        public string Type { get; set; }

        [KicadParameter(1)]
        public double Width { get; set; }
    }
}
