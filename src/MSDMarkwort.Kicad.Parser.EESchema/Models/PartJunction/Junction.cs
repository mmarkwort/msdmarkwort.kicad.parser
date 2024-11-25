using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;
using System;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartJunction
{
    public class Junction
    {
        [KicadParserComplexSymbol("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadParserSymbol("diameter")]
        public double Diameter { get; set; }

        [KicadParserComplexSymbol("color")]
        public Color Color { get; set; } = new Color();

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }
    }
}
