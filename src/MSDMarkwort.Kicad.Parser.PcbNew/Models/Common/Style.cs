using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class Style
    {
        [KicadElement("thickness")]
        public double Thickness { get; set; }

        [KicadElement("arrow_length")]
        public double ArrowLength { get; set; }

        [KicadElement("text_position_mode")]
        public int TextPositionMode { get; set; }

        [KicadElement("extension_height")]
        public double ExtensionHeight { get; set; }

        [KicadElement("extension_offset")]
        public ExtensionOffset ExtensionOffset { get; set; } = new ExtensionOffset();
    }
}
