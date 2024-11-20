using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class FilledPolygon : IPts
    {
        [KicadElement("layer")]
        public string Layer { get; set; }

        [KicadElement("pts")]
        public MultiPointPositionXY Pts { get; set; } = new MultiPointPositionXY();
    }
}
