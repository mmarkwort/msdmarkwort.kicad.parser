using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class GrBase
    {
        [KicadParserSymbol("locked", parameterMappings: "locked")]
        public bool IsLocked { get; set; }

        [KicadParserComplexSymbol("stroke")]
        public Stroke Stroke { get; set; } = new Stroke();

        [KicadParserSymbol("fill")]
        public string Fill { get; set; }

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
