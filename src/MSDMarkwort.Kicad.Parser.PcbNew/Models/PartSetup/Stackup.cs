using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup
{
    public class Stackup
    {
        [KicadParserList("layer", KicadParserListAddType.Complex)]
        public LayerCollection Layers { get; set; } = new LayerCollection();

        [KicadParserSymbol("copper_finish")]
        public string CopperFinish { get; set; }

        [KicadParserSymbol("dielectric_constraints")]
        public bool DielectricConstraints { get; set; }
    }
}
