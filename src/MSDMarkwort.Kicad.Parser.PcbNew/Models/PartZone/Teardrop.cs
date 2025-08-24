using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public enum TeardropType
    {
        TrackEnd,
        PadVia,
        Fillet,
        Curved
    }

    public class Teardrop
    {
        [KicadParserSymbol("type")]
        public TeardropType Type { get; set; }
    }
}
