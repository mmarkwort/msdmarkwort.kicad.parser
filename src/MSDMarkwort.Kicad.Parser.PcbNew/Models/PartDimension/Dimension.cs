using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr;
using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartDimension
{
    public class Dimension : IPts
    {
        [KicadParserSymbol("type")]
        public string Type { get; set; }

        [KicadParserSymbol("layer")]
        public string Layer { get; set; }

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserSymbol("tstamp")]
        public Guid TStamp { get; set; }

        [KicadParserComplexSymbol("pts")]
        public MultiPointPositionXY Pts { get; set; } = new MultiPointPositionXY();

        [KicadParserSymbol("height")]
        public double Height { get; set; }

        [KicadParserSymbol("orientation")]
        public double Orientation { get; set; }

        [KicadParserComplexSymbol("gr_text")]
        public GrText GrText { get; set; } = new GrText();

        [KicadParserComplexSymbol("format")]
        public Format Format { get; set; } = new Format();

        [KicadParserComplexSymbol("style")]
        public Style Style { get; set; } = new Style();
    }
}
