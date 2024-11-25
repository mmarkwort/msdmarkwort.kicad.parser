using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartShapes
{
    public class Circle
    {
        [KicadParserComplexSymbol("center")]
        public Position StartPosition { get; set; } = new Position();

        [KicadParserSymbol("radius")]
        public double Radius { get; set; }

        [KicadParserComplexSymbol("stroke")]
        public Stroke Stroke { get; set; } = new Stroke();

        [KicadParserComplexSymbol("fill")]
        public Fill Fill { get; set; } = new Fill();
    }
}
