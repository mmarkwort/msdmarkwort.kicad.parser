using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Placement
    {
        [KicadElement("enabled")]
        public bool Enabled { get; set; }

        [KicadElement("sheetname")]
        public string SheetName { get; set; }
    }
}
