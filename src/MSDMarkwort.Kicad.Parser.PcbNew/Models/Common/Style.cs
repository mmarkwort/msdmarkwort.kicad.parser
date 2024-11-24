using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class Style
    {
        [KicadParserSymbol("thickness")]
        public double Thickness { get; set; }

        [KicadParserSymbol("arrow_length")]
        public double ArrowLength { get; set; }

        [KicadParserSymbol("text_position_mode")]
        public int TextPositionMode { get; set; }

        [KicadParserSymbol("extension_height")]
        public double ExtensionHeight { get; set; }

        [KicadParserComplexSymbol("extension_offset")]
        public ExtensionOffset ExtensionOffset { get; set; } = new ExtensionOffset();
    }
}
