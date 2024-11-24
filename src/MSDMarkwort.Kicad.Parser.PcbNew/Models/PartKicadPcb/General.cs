using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb
{
    public class General
    {
        [KicadParserSymbol("thickness")]
        public double Thickness { get; set; }

        [KicadParserSymbol("legacy_teardrops")]
        public bool LegacyTearDrops { get; set; }
    }
}
