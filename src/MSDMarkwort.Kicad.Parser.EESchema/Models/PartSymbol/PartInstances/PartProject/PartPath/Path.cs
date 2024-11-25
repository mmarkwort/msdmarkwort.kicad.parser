using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartInstances.PartProject.PartPath
{
    public class Path
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParserSymbol("reference")]
        public string Reference { get; set; }

        [KicadParserSymbol("unit")]
        public int Unit { get; set; }
    }
}
