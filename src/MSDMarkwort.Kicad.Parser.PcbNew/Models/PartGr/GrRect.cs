using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class GrRect : GrBase
    {
        [KicadElement("start")]
        public Position StartPosition { get; set; } = new Position();

        [KicadElement("end")]
        public Position EndPosition { get; set; } = new Position();

        public override string ToString()
        {
            return $"{StartPosition.X}/{StartPosition.Y}-{EndPosition.X}/{EndPosition.Y} ({Layer})";
        }
    }
}
