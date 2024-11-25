using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartInstances.PartProject.PartPath
{
    public class Path
    {
        [KicadParameter(0)]
        public string AbsolutePath { get; set; }

        [KicadParserSymbol("reference")]
        public string Reference { get; set; }

        [KicadParserSymbol("unit")]
        public int Unit { get; set; }

        [KicadParserSymbol("page")]
        public string Page { get; set; }

        [KicadParserSymbol("value")]
        public string Value { get; set; }

        [KicadParserSymbol("footprint")]
        public string Footprint { get; set; }
    }
}
