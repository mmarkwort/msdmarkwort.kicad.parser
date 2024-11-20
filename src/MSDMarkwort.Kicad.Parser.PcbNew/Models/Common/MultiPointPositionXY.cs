using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class MultiPointPositionXY
    {
        [KicadElement("xy")]
        public List<Position> Positions { get; set; } = new List<Position>();
    }
}
