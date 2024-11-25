using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartPin
{
    public class Pin
    {
        [KicadParameter(0)]
        public string ElectricalPinType { get; set; }

        [KicadParameter(1)]
        public string GraphicPinShape { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt At { get; set; } = new PositionAt();

        [KicadParserSymbol("hide", parameterMappings: "hide")]
        public bool Hide { get; set; }

        [KicadParserSymbol("length")]
        public bool Length { get; set; }

        [KicadParserComplexSymbol("name")]
        public PinName PinName { get; set; } = new PinName();

        [KicadParserComplexSymbol("number")]
        public PinNumber PinNumber { get; set; } = new PinNumber();

    }
}
