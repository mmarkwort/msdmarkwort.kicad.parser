using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartFp
{
    public class FpBase
    {
        [KicadParserSymbol("layer")]
        public string Layer { get; set; }

        [KicadParserComplexSymbol("stroke")]
        public Stroke Stroke { get; set; } = new Stroke();

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }
    }
}
