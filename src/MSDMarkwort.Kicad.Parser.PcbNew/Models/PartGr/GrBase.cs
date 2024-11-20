using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class GrBase
    {
        [KicadElement("stroke")]
        public Stroke Stroke { get; set; } = new Stroke();

        [KicadElement("fill")]
        public string Fill { get; set; }

        [KicadElement("layer")]
        public string Layer { get; set; }

        [KicadElement("net")]
        public int Net { get; set; } = -1;

        [KicadElement("uuid")]
        public Guid Uuid { get; set; }
    }
}
