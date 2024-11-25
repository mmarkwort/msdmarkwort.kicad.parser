using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class MultiPointPositionXY
    {
        [KicadParserList("xy", KicadParserListAddType.Complex)]
        public List<Position> Positions { get; set; } = new List<Position>();
    }
}
