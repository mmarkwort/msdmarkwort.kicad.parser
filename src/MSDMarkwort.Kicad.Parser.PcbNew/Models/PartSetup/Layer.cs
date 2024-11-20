using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup
{
    public class Layer
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadElement("type")]
        public string Type { get; set; }

        [KicadElement("thickness")]
        public double Thickness { get; set; }

        [KicadElement("color")]
        public string Color { get; set; }


        [KicadElement("material")]
        public string Material { get; set; }

        [KicadElement("epsilon_r")]
        public double EpsilonR { get; set; }

        [KicadElement("loss_tangent")]
        public double LossTangent { get; set; }
    }
}
