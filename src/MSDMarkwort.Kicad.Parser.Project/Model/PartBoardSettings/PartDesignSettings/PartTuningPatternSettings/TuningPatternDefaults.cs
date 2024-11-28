using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartTuningPatternSettings
{
    public class TuningPatternDefaults
    {
        [JsonPropertyName("corner_radius_percentage")]
        public int CornerRadiusPercentage { get; set; }

        [JsonPropertyName("corner_style")]
        public int CornerStyle { get; set; }

        [JsonPropertyName("max_amplitude")]
        public double MaxAmplitude { get; set; }

        [JsonPropertyName("min_amplitude")]
        public double MinAmplitude { get; set; }

        [JsonPropertyName("single_sided")]
        public bool SingleSided { get; set; }

        [JsonPropertyName("spacing")]
        public double Spacing { get; set; }
    }
}
