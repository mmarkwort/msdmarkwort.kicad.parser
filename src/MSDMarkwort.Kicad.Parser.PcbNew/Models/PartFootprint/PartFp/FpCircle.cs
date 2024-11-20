using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartFp
{
    public class FpCircle : FpBase
    {
        [KicadElement("center")]
        public Position Center { get; set; } = new Position();

        [KicadElement("end")]
        public Position EndPosition { get; set; } = new Position();

        [KicadElement("fill")]
        public string Fill { get; set; }

        public override string ToString()
        {
            return $"{Center.X}/{Center.Y}-{EndPosition.X}/{EndPosition.Y} ({Layer})";
        }
    }
}
