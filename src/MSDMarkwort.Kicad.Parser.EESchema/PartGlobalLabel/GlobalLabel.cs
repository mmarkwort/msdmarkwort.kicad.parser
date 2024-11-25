using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartProperty;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema.PartGlobalLabel
{
    public class GlobalLabel
    {
        [KicadParameter(0)]
        public string Text { get; set; }

        [KicadParserSymbol("shape")]
        public string Shape { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadParserSymbol("fields_autoplaced")]
        public bool FieldsAutoplaced { get; set; }

        [KicadParserComplexSymbol("effects")]
        public Effects Effects { get; set; } = new Effects();

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserList("property", KicadParserListAddType.Complex)]
        public PropertyCollection Properties { get; set; } = new PropertyCollection();
    }
}
