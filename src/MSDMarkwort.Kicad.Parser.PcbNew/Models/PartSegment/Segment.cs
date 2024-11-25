using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSegment
{
    public class Segment
    {
        [KicadParserSymbol("start")]
        public Position StartPosition { get; set; } = new Position();

        [KicadParserSymbol("end")]
        public Position EndPosition { get; set; } = new Position();

        [KicadParserSymbol("width")]
        public double Width { get; set; }

        [KicadParserSymbol("locked")]
        public bool Locked { get; set; }

        [KicadParserSymbol("layer")]
        public string Layer { get; set; }

        [KicadParserSymbol("net")]
        public int Net { get; set; } = -1;

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserSymbol("tstamp")]
        public Guid TStamp { get; set; }
    }
}
