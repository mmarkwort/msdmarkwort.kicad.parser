﻿using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class GrCircle : GrBase
    {
        [KicadParserComplexSymbol("center")]
        public Position CenterPosition { get; set; } = new Position();

        [KicadParserComplexSymbol("end")]
        public Position EndPosition { get; set; } = new Position();

        [KicadParserSymbol("width")]
        public double Width { get; set; }

        public override string ToString()
        {
            return $"{CenterPosition.X}/{CenterPosition.Y}-{EndPosition.X}/{EndPosition.Y} ({Layer})";
        }
    }
}
