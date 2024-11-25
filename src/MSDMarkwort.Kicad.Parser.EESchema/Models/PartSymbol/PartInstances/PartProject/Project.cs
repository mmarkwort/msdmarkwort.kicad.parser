using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartInstances.PartProject.PartPath;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartInstances.PartProject
{
    public class Project
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParserList("path", KicadParserListAddType.Complex)]
        public PathCollection Paths { get; set; } = new PathCollection();
    }
}
