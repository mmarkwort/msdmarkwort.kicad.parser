using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartHierarchicalLabel
{
    public enum LabelShape
    {
        Input,
        Output,
        Bidirectional,
        TriState,
        Passive
    }

    public class HierarchicalLabel
    {
        [KicadParameter(0)]
        public string Text { get; set; }

        [KicadParserSymbol("shape")]
        public LabelShape ShapeType { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadParserSymbol("fields_autoplaced")]
        public bool FieldsAutoplaced { get; set; }

        [KicadParserComplexSymbol("effects")]
        public Effects Effects { get; set; } = new Effects();

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }
    }
}
