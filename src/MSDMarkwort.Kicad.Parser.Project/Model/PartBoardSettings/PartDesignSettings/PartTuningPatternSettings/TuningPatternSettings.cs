using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartTuningPatternSettings
{
    public class TuningPatternSettings
    {
        [JsonPropertyName("diff_pair_defaults")]
        public TuningPatternDefaults DiffPairDefaults { get; set; }

        [JsonPropertyName("diff_pair_skew_defaults")]
        public TuningPatternDefaults DiffPairSkewDefaults { get; set; }

        [JsonPropertyName("single_track_defaults")]
        public TuningPatternDefaults SingleTrackDefaults { get; set; }
    }
}
