using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad
{
    public class Options
    {
        [KicadParserSymbol("clearance")]
        public string Clearance { get; set; }

        [KicadParserSymbol("anchor")]
        public string Anchor { get; set; }
    }
}
