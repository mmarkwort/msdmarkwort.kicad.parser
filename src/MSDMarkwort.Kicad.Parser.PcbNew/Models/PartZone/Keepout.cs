using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Keepout
    {
        [KicadElement("tracks")]
        public string Tracks { get; set; }

        [KicadElement("vias")]
        public string Vias { get; set; }

        [KicadElement("pads")]
        public string Pads { get; set; }

        [KicadElement("copperpour")]
        public string CopperPour { get; set; }

        [KicadElement("footprints")]
        public string Footprints { get; set; }
    }
}
