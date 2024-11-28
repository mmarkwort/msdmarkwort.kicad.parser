using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartDefaults.PartDimensions
{
    public class Dimensions
    {
        [JsonPropertyName("arrow_length")]
        public int ArrowLength { get; set; }

        [JsonPropertyName("extension_offset")]
        public int ExtensionOffset { get; set; }

        [JsonPropertyName("keep_text_aligned")]
        public bool KeepTextAligned { get; set; }

        [JsonPropertyName("suppress_zeroes")]
        public bool SuppressZeroes { get; set; }

        [JsonPropertyName("text_position")]
        public int TextPosition { get; set; }

        [JsonPropertyName("units_format")]
        public int UnitsFormat { get; set; }
    }
}