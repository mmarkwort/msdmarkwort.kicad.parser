using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Keepout
    {
        [KicadParserSymbol("tracks")]
        public string Tracks { get; set; }

        [KicadParserSymbol("vias")]
        public string Vias { get; set; }

        [KicadParserSymbol("pads")]
        public string Pads { get; set; }

        [KicadParserSymbol("copperpour")]
        public string CopperPour { get; set; }

        [KicadParserSymbol("footprints")]
        public string Footprints { get; set; }
    }
}
