﻿using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class GrPoly : GrBase, IPts
    {
        [KicadElement("pts")]
        public MultiPointPositionXY Pts { get; set; } = new MultiPointPositionXY();

        [KicadElement("width")]
        public double Width { get; set; }
    }
}
