using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Teardrop
    {
        [KicadParserSymbol("type")]
        public string Type { get; set; }
    }
}
