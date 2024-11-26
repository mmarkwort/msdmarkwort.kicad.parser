using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartModel
{
    public class Model
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParserSymbol("hide", parameterMappings: "hide")]
        public bool Hide { get; set; }

        [KicadParserComplexSymbol("offset")]
        public PositionXYZProxy Offset { get; set; } = new PositionXYZProxy();

        [KicadParserComplexSymbol("scale")]
        public PositionXYZProxy Scale { get; set; } = new PositionXYZProxy();

        [KicadParserComplexSymbol("rotate")]
        public PositionXYZProxy Rotate { get; set; } = new PositionXYZProxy();

        [KicadParserComplexSymbol("at")]
        public PositionXYZProxy At { get; set; } = new PositionXYZProxy();
    }
}
