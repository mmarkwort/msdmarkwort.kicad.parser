using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSegment
{
    public class Segment
    {
        [KicadElement("start")]
        public Position StartPosition { get; set; } = new Position();

        [KicadElement("end")]
        public Position EndPosition { get; set; } = new Position();

        [KicadElement("width")]
        public double Width { get; set; }

        [KicadElement("locked")]
        public bool Locked { get; set; }

        [KicadElement("layer")]
        public string Layer { get; set; }

        [KicadElement("net")]
        public int Net { get; set; } = -1;

        [KicadElement("uuid")]
        public Guid Uuid { get; set; }
    }
}
