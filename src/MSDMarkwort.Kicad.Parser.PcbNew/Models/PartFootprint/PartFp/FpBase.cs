using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartFp
{
    public class FpBase
    {
        [KicadElement("layer")]
        public string Layer { get; set; }

        [KicadElement("stroke")]
        public Stroke Stroke { get; set; } = new Stroke();

        [KicadElement("uuid")]
        public Guid Uuid { get; set; }
    }
}
