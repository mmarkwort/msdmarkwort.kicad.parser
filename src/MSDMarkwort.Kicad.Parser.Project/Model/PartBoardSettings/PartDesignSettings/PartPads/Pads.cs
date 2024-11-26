using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartPads
{
    public class Pads
    {
        [JsonPropertyName("drill")]
        public double Drill { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("width")]
        public double Width { get; set; }
    }
}