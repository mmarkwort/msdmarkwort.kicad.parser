using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb
{
    public class General
    {
        [KicadElement("thickness")]
        public double Thickness { get; set; }

        [KicadElement("legacy_teardrops")]
        public bool LegacyTearDrops { get; set; }
    }
}
