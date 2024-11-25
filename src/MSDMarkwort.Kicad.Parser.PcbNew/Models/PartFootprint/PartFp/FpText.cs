using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartFp
{
    public class FpText : FpBase
    {
        [KicadParameter(0)]
        public string Type { get; set; }

        [KicadParameter(1)]
        public string Text { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadParserSymbol("hide")]
        public bool Hide { get; set; }

        [KicadParserSymbol("unlocked")]
        public bool Unlocked { get; set; }

        [KicadParserComplexSymbol("effects")]
        public Effects Effects { get; set; } = new Effects();

        [KicadParserComplexSymbol("render_cache")]
        public RenderCache RenderCache { get; set; } = new RenderCache();

        public override string ToString()
        {
            return $"{Type}: {Text}";
        }
    }
}
