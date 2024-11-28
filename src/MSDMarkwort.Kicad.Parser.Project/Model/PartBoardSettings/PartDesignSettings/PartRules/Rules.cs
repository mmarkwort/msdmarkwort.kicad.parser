using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartRules
{
    public class Rules
    {
        [JsonPropertyName("allow_blind_buried_vias")]
        public bool AllowBlindBuriedVias { get; set; }

        [JsonPropertyName("allow_microvias")]
        public bool AllowMicrovias { get; set; }

        [JsonPropertyName("max_error")]
        public double MaxError { get; set; }

        [JsonPropertyName("min_clearance")]
        public double MinClearance { get; set; }

        [JsonPropertyName("min_connection")]
        public double MinConnection { get; set; }

        [JsonPropertyName("min_copper_edge_clearance")]
        public double MinCopperEdgeClearance { get; set; }

        [JsonPropertyName("min_groove_width")]
        public double MinGrooveWidth { get; set; }

        [JsonPropertyName("min_hole_clearance")]
        public double MinHoleClearance { get; set; }

        [JsonPropertyName("min_hole_to_hole")]
        public double MinHoleToHole { get; set; }

        [JsonPropertyName("min_microvia_diameter")]
        public double MinMicroviaDiameter { get; set; }

        [JsonPropertyName("min_microvia_drill")]
        public double MinMicroviaDrill { get; set; }

        [JsonPropertyName("min_resolved_spokes")]
        public int MinResolvedSpokes { get; set; }

        [JsonPropertyName("min_silk_clearance")]
        public double MinSilkClearance { get; set; }

        [JsonPropertyName("min_text_height")]
        public double MinTextHeight { get; set; }

        [JsonPropertyName("min_text_thickness")]
        public double MinTextThickness { get; set; }

        [JsonPropertyName("min_through_hole_diameter")]
        public double MinThroughHoleDiameter { get; set; }

        [JsonPropertyName("min_track_width")]
        public double MinTrackWidth { get; set; }

        [JsonPropertyName("min_via_annulus")]
        public double MinViaAnnulus { get; set; }

        [JsonPropertyName("min_via_annular_width")]
        public double MinViaAnnularWidth { get; set; }

        [JsonPropertyName("min_via_diameter")]
        public double MinViaDiameter { get; set; }

        [JsonPropertyName("solder_mask_to_copper_clearance")]
        public double SolderMaskToCopperClearance { get; set; }

        [JsonPropertyName("solder_mask_clearance")]
        public double SolderMaskClearance { get; set; }

        [JsonPropertyName("solder_mask_min_width")]
        public double SolderMaskMinWidth { get; set; }

        [JsonPropertyName("solder_paste_clearance")]
        public double SolderPasteClearance { get; set; }

        [JsonPropertyName("solder_paste_margin_ratio")]
        public double SolderPasteMarginRatio { get; set; }

        [JsonPropertyName("use_height_for_length_calcs")]
        public bool UseHeightForLengthCalcs { get; set; }
    }
}
