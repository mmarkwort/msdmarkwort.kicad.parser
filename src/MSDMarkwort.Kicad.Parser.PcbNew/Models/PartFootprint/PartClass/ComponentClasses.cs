using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartClass
{
    public class ComponentClasses
    {
        [KicadParserList("class", KicadParserListAddType.Complex)]
        public ClassCollection ClassCollection { get; set; } = new ClassCollection();
    }
}
