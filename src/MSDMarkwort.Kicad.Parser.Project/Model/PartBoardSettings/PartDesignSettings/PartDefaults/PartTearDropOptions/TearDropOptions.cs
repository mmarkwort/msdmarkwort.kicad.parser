using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartDefaults.PartTearDropOptions
{
    public class TearDropOptions
    {
        [JsonPropertyName("td_allow_use_two_tracks")]
        public bool TdAllowUseTwoTracks { get; set; }

        [JsonPropertyName("td_curve_segcount")]
        public int TdCurveSegCount { get; set; }

        [JsonPropertyName("td_on_pad_in_zone")]
        public bool TdOnPadInZone { get; set; }

        [JsonPropertyName("td_onpthpad")]
        public bool TdOnPthPad { get; set; }

        [JsonPropertyName("td_onpadsmd")]
        public bool TdOnPadSmd { get; set; }

        [JsonPropertyName("td_onsmdpad")]
        public bool TdOnSmdPad { get; set; }

        [JsonPropertyName("td_onroundshapesonly")]
        public bool TdOnRoundShapesOnly { get; set; }

        [JsonPropertyName("td_ontrackend")]
        public bool TdOnTrackEnd { get; set; }

        [JsonPropertyName("td_onviapad")]
        public bool TdOnViaPad { get; set; }

        [JsonPropertyName("td_onvia")]
        public bool TdOnVia { get; set; }
    }
}
