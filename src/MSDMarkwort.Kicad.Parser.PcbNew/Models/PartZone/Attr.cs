using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Attr
    {
        [KicadParserComplexSymbol("teardrop")]
        public Teardrop Teardrop { get; set; } = new Teardrop();
    }
}
