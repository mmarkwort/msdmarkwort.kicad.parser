using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartDefaultInstance
{
    public class DefaultInstance
    {
        [KicadParserSymbol("reference")]
        public string Reference { get; set; }

        [KicadParserSymbol("unit")]
        public int Unit { get; set; }

        [KicadParserSymbol("value")]
        public string Value { get; set; }

        [KicadParserSymbol("footprint")]
        public string Footprint { get; set; }
    }
}
