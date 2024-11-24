using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad;
using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartVia
{
    public class Via
    {
        [KicadParserComplexSymbol("at")]
        public PositionAt Position { get; set; } = new PositionAt();

        [KicadParserSymbol("size")]
        public double Size { get; set; }

        [KicadParserSymbol("drill")]
        public double Drill { get; set; }

        [KicadParserSymbol("free")]
        public bool Free { get; set; }

        [KicadParserList("layers", KicadParserListAddType.FromParameters)]
        public List<string> Layers { get; set; } = new List<string>();

        [KicadParserSymbol("locked")]
        public bool Locked { get; set; }

        [KicadParserComplexSymbol("teardrops")]
        public Teardrops Teardrops { get; set; } = new Teardrops();

        [KicadParserSymbol("net")]
        public int Net { get; set; } = -1;

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }
    }
}
