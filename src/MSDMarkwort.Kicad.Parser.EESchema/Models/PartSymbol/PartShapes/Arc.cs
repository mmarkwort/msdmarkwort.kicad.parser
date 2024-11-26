using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartShapes
{
    public class Arc
    {
        [KicadParserComplexSymbol("start")]
        public Position StartPosition { get; set; } = new Position();

        [KicadParserComplexSymbol("mid")]
        public Position MidPosition { get; set; } = new Position();

        [KicadParserComplexSymbol("end")]
        public Position EndPosition { get; set; } = new Position();

        [KicadParserComplexSymbol("stroke")]
        public Stroke Stroke { get; set; } = new Stroke();

        [KicadParserComplexSymbol("fill")]
        public Fill Fill { get; set; } = new Fill();

        [KicadParserComplexSymbol("radius")]
        public Radius Radius { get; set; } = new Radius();
    }
}
