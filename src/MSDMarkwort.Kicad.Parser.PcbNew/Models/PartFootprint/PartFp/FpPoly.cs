using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartFp
{
    public class FpPoly : FpBase, IPts
    {
        [KicadElement("pts")]
        public MultiPointPositionXY Pts { get; set; } = new MultiPointPositionXY();

        [KicadElement("fill")]
        public string Fill { get; set; }
    }
}
