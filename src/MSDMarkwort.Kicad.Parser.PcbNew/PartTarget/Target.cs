using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.PartTarget
{
    public class Target
    {
        [KicadParameter(0)]
        public string Type { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt At { get; set; } = new PositionAt();

        [KicadParserSymbol("size")]
        public double Size { get; set; }

        [KicadParserSymbol("width")]
        public double Width { get; set; }

        [KicadParserSymbol("layer")]
        public string Layer { get; set; }

        [KicadParserSymbol("tstamp")]
        public Guid TStamp { get; set; }

    }
}
//(target plus (at 96.52 144.78) (size 5) (width 0.15) (layer "Edge.Cuts") (tstamp 0656fbe8-d593-4158-9bf3-80d6a1b2e6a0))