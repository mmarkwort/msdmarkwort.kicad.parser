using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup
{
    public class Layer
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParserSymbol("type")]
        public string Type { get; set; }

        [KicadParserSymbol("thickness")]
        public double Thickness { get; set; }

        [KicadParserSymbol("color")]
        public string Color { get; set; }

        [KicadParserSymbol("material")]
        public string Material { get; set; }

        [KicadParserSymbol("epsilon_r")]
        public double EpsilonR { get; set; }

        [KicadParserSymbol("loss_tangent")]
        public double LossTangent { get; set; }
    }
}
