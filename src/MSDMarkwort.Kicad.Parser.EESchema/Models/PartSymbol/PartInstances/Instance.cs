using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartInstances.PartProject;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartInstances
{
    public class Instance
    {
        [KicadParserList("project", KicadParserListAddType.Complex)]
        public ProjectCollection Projects { get; set; } = new ProjectCollection();
    }
}
