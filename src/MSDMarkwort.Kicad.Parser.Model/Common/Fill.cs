﻿using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Fill
    {
        [KicadParserSymbol("type")]
        public string Type { get; set; }
    }
}
