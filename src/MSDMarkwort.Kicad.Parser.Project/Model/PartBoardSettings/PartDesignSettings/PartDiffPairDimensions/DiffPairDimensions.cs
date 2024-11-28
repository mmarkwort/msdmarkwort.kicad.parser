using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartDiffPairDimensions
{
    public class DiffPairDimensions
    {
        [JsonPropertyName("gap")]
        public double Gap { get; set; }

        [JsonPropertyName("via_gap")]
        public double ViaGap { get; set; }

        [JsonPropertyName("width")]
        public double Width { get; set; }
    }
}
