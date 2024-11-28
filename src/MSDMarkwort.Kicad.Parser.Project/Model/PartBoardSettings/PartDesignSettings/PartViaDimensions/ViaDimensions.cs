using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartViaDimensions
{
    public class ViaDimensions
    {
        [JsonPropertyName("diameter")]
        public double Diameter { get; set; }

        [JsonPropertyName("drill")]
        public double Drill { get; set; }
    }
}
