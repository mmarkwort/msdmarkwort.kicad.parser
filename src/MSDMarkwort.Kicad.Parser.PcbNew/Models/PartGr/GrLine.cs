using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class GrLine : GrBase
    {
        [KicadElement("start")]
        public Position StartPosition { get; set; } = new Position();

        [KicadElement("end")]
        public Position EndPosition { get; set; } = new Position();

        [KicadElement("width")]
        public double Width { get; set; }

        public override string ToString()
        {
            return $"{StartPosition.X}/{StartPosition.Y}-{EndPosition.X}/{EndPosition.Y} ({Layer})";
        }
    }
}
