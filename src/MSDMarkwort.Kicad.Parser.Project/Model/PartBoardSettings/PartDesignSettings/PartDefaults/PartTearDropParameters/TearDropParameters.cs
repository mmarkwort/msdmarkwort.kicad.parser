
using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartDefaults.PartTearDropParameters
{
    public class TearDropParameters
    {
        [JsonPropertyName("td_allow_use_two_tracks")]
        public bool TdAllowUseTwoTracks { get; set; }

        [JsonPropertyName("td_curve_segcount")]
        public int TdCurveSegcount { get; set; }

        [JsonPropertyName("td_height_ratio")]
        public double TdHeightRatio { get; set; }

        [JsonPropertyName("td_length_ratio")]
        public double TdLengthRatio { get; set; }

        [JsonPropertyName("td_maxheight")]
        public double TdMaxheight { get; set; }

        [JsonPropertyName("td_maxlen")]
        public double TdMaxlen { get; set; }

        [JsonPropertyName("td_on_pad_in_zone")]
        public bool TdOnPadInZone { get; set; }

        [JsonPropertyName("td_target_name")]
        public string TdTargetName { get; set; }

        [JsonPropertyName("td_width_to_size_filter_ratio")]
        public double TdWidthToSizeFilterRatio { get; set; }
    }
}