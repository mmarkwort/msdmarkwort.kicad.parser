using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartFp
{
    public class FpArc : FpBase
    {
        [KicadParserComplexSymbol("start")]
        public Position StartPosition { get; set; } = new Position();

        [KicadParserComplexSymbol("mid")]
        public Position MidPosition { get; set; } = new Position();

        [KicadParserComplexSymbol("end")]
        public Position EndPosition { get; set; } = new Position();

        public override string ToString()
        {
            return $"{StartPosition.X}/{StartPosition.Y}-{EndPosition.X}/{EndPosition.Y} ({Layer})";
        }
    }
}
