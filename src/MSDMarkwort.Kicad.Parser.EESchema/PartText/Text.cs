using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;
using System;

namespace MSDMarkwort.Kicad.Parser.EESchema.PartText
{
    public class Text
    {
        [KicadParameter(0)]
        public string TextValue { get; set; }

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadParserComplexSymbol("effects")]
        public Effects Effects { get; set; } = new Effects();

        [KicadParserSymbol("exclude_from_sim")]
        public bool ExcludeFromSim { get; set; }
    }
}
