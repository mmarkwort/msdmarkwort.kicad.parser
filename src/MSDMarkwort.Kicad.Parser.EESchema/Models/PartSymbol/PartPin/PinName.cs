using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartPin
{
    public class PinName
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParserComplexSymbol("effects")]
        public Effects Effects { get; set; } = new Effects();
    }
}
