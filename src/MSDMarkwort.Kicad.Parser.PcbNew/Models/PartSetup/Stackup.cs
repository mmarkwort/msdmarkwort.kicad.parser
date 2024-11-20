using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup
{
    public class Stackup
    {
        [KicadElement("layer")]
        public LayerCollection Layers { get; set; } = new LayerCollection();

        [KicadElement("copper_finish")]
        public string CopperFinish { get; set; }

        [KicadElement("dielectric_constraints")]
        public bool DielectricConstraints { get; set; }
    }
}
