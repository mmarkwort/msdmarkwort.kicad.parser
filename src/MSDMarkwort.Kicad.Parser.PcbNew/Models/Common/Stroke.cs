﻿using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class Stroke
    {
        [KicadParserSymbol("width")]
        public double Width { get; set; }

        [KicadParserSymbol("type")]
        public string Type { get; set; }
    }
}
