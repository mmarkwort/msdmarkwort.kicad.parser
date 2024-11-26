using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartShapes
{
    public class Radius
    {
        [KicadParserComplexSymbol("at")]
        public PositionAt At { get; set; } = new PositionAt();

        [KicadParserSymbol("length")]
        public double Length { get; set; }

        [KicadParserComplexSymbol("angles")]
        public PositionAt Angles { get; set; } = new PositionAt();
    }
}
