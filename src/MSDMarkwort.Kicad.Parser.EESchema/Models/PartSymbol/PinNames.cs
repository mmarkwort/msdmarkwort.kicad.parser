using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol
{
    public class PinNames
    {
        [KicadParserSymbol("hide", parameterMappings: "hide")]
        public bool Hide { get; set; }

        [KicadParserSymbol("offset")]
        public double Offset { get; set; }
    }
}
