using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common.Enums;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Style
    {
        [KicadParserSymbol("thickness")]
        public double Thickness { get; set; }

        [KicadParserSymbol("arrow_length")]
        public double ArrowLength { get; set; }

        [KicadParserSymbol("text_position_mode")]
        public int TextPositionMode { get; set; }

        [KicadParserSymbol("text_frame")]
        public int TextFrame { get; set; }        

        [KicadParserSymbol("extension_height")]
        public double ExtensionHeight { get; set; }

        [KicadParserSymbol("extension_offset")]
        public string ExtensionOffset { get; set; }

        [KicadParameter(0)]
        public HorizontalAlignment Alignment { get; set; }
    }
}
