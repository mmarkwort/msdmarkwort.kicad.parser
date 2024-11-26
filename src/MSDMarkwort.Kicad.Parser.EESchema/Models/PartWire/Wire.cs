using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartWire
{
    public class Wire
    {
        [KicadParserComplexSymbol("pts")]
        public MultiPointPositionXY Pts { get; set; } = new MultiPointPositionXY();

        [KicadParserComplexSymbol("stroke")]
        public Stroke Stroke { get; set; } = new Stroke();

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }
    }
}
