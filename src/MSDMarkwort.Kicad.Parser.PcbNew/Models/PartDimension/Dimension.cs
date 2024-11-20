using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr;
using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartDimension
{
    public class Dimension : IPts
    {
        [KicadElement("type")]
        public string Type { get; set; }

        [KicadElement("layer")]
        public string Layer { get; set; }

        [KicadElement("uuid")]
        public Guid Uuid { get; set; }

        [KicadElement("pts")]
        public MultiPointPositionXY Pts { get; set; } = new MultiPointPositionXY();

        [KicadElement("height")]
        public double Height { get; set; }

        [KicadElement("gr_text")]
        public GrText GrText { get; set; } = new GrText();

        [KicadElement("format")]
        public Format Format { get; set; } = new Format();

        [KicadElement("style")]
        public Style Style { get; set; } = new Style();
    }
}
