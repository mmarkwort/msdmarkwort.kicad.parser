using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class GrText : GrBase
    {
        [KicadParameter(0)]
        public string Text { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt Position { get; set; } = new PositionAt();

        [KicadParserComplexSymbol("effects")]
        public Effects Effects { get; set; } = new Effects();

        [KicadParserComplexSymbol("render_cache")]
        public RenderCache RenderCache { get; set; } = new RenderCache();

        public override string ToString()
        {
            return $"{Text} - {Position.X}/{Position.Y} ({Layer})";
        }
    }
}
