using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartFp
{
    public class FpCircle : FpBase
    {
        [KicadParserComplexSymbol("center")]
        public Position Center { get; set; } = new Position();

        [KicadParserComplexSymbol("end")]
        public Position EndPosition { get; set; } = new Position();

        [KicadParserSymbol("fill")]
        public string Fill { get; set; }

        [KicadParserSymbol("width")]
        public double Width { get; set; }

        public override string ToString()
        {
            return $"{Center.X}/{Center.Y}-{EndPosition.X}/{EndPosition.Y} ({Layer})";
        }
    }
}
