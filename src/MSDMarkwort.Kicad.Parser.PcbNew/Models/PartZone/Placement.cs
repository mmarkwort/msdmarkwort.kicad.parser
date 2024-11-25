using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Placement
    {
        [KicadParserSymbol("enabled")]
        public bool Enabled { get; set; }

        [KicadParserSymbol("sheetname")]
        public string SheetName { get; set; }
    }
}
