using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;
using System;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartShapes
{
    public class Polyline
    {
        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserComplexSymbol("pts")]
        public MultiPointPositionXY Pts { get; set; } = new MultiPointPositionXY();

        [KicadParserComplexSymbol("stroke")]
        public Stroke Stroke { get; set; } = new Stroke();

        [KicadParserComplexSymbol("fill")]
        public Fill Fill { get; set; } = new Fill();
    }
}
