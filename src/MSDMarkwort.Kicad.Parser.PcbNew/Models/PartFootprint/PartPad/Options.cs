using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad
{
    public class Options
    {
        [KicadElement("clearance")]
        public string Clearance { get; set; }

        [KicadElement("anchor")]
        public string Anchor { get; set; }
    }
}
