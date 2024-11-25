using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartProperty
{
    public class Property
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParameter(1)]
        public string Value { get; set; }

        [KicadParserSymbol("id")]
        public int Id { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadParserSymbol("hide")]
        public bool Hide { get; set; }

        [KicadParserComplexSymbol("effects")]
        public Effects Effects { get; set; } = new Effects();

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}
