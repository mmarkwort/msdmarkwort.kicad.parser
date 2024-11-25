using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class GrArc : GrBase
    {
        [KicadParserComplexSymbol("start")]
        public Position StartPosition { get; set; } = new Position();

        [KicadParserComplexSymbol("mid")]
        public Position MidPosition { get; set; } = new Position();

        [KicadParserComplexSymbol("end")]
        public Position EndPosition { get; set; } = new Position();

        [KicadParserSymbol("width")]
        public double Width { get; set; }

        [KicadParserSymbol("angle")]
        public double Angle { get; set; }

        public override string ToString()
        {
            return $"{StartPosition.X}/{StartPosition.Y}-{MidPosition.X / MidPosition.Y}-{EndPosition.X}/{EndPosition.Y} ({Layer})";
        }
    }
}
