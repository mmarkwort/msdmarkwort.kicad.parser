using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartRuleSeverities
{
    public class RuleSeverities
    {
        [JsonPropertyName("annular_width")]
        public string AnnularWidth { get; set; }

        [JsonPropertyName("clearance")]
        public string Clearance { get; set; }

        [JsonPropertyName("connection_width")]
        public string ConnectionWidth { get; set; }

        [JsonPropertyName("copper_edge_clearance")]
        public string CopperEdgeClearance { get; set; }

        [JsonPropertyName("copper_sliver")]
        public string CopperSliver { get; set; }

        [JsonPropertyName("courtyards_overlap")]
        public string CourtyardsOverlap { get; set; }

        [JsonPropertyName("creepage")]
        public string CreePage { get; set; }

        [JsonPropertyName("diff_pair_gap_out_of_range")]
        public string DiffPairGapOutOfRange { get; set; }

        [JsonPropertyName("diff_pair_uncoupled_length_too_long")]
        public string DiffPairUncoupledLengthTooLong { get; set; }

        [JsonPropertyName("drill_out_of_range")]
        public string DrillOutOfRange { get; set; }

        [JsonPropertyName("duplicate_footprints")]
        public string DuplicateFootprints { get; set; }

        [JsonPropertyName("extra_footprint")]
        public string ExtraFootprint { get; set; }

        [JsonPropertyName("footprint")]
        public string Footprint { get; set; }

        [JsonPropertyName("footprint_filters_mismatch")]
        public string FootprintFiltersMismatch { get; set; }

        [JsonPropertyName("footprint_symbol_mismatch")]
        public string FootprintSymbolMismatch { get; set; }

        [JsonPropertyName("footprint_type_mismatch")]
        public string FootprintTypeMismatch { get; set; }

        [JsonPropertyName("hole_clearance")]
        public string HoleClearance { get; set; }

        [JsonPropertyName("hole_near_hole")]
        public string HoleNearHole { get; set; }

        [JsonPropertyName("hole_to_hole")]
        public string HoleToHole { get; set; }

        [JsonPropertyName("holes_co_located")]
        public string HolesCoLocated { get; set; }

        [JsonPropertyName("invalid_outline")]
        public string InvalidOutline { get; set; }

        [JsonPropertyName("isolated_copper")]
        public string IsolatedCopper { get; set; }

        [JsonPropertyName("item_on_disabled_layer")]
        public string ItemOnDisabledLayer { get; set; }

        [JsonPropertyName("items_not_allowed")]
        public string ItemsNotAllowed { get; set; }

        [JsonPropertyName("length_out_of_range")]
        public string LengthOutOfRange { get; set; }

        [JsonPropertyName("lib_footprint_issues")]
        public string LibFootprintIssues { get; set; }

        [JsonPropertyName("lib_footprint_mismatch")]
        public string LibFootprintMismatch { get; set; }

        [JsonPropertyName("malformed_courtyard")]
        public string MalformedCourtyard { get; set; }

        [JsonPropertyName("microvia_drill_out_of_range")]
        public string MicroViaDrillOutOfRange { get; set; }

        [JsonPropertyName("missing_courtyard")]
        public string MissingCourtyard { get; set; }

        [JsonPropertyName("missing_footprint")]
        public string MissingFootprint { get; set; }

        [JsonPropertyName("net_conflict")]
        public string NetConflict { get; set; }

        [JsonPropertyName("npth_inside_courtyard")]
        public string NpthInsideCourtyard { get; set; }

        [JsonPropertyName("overlapping_pads")]
        public string OverlappingPads { get; set; }

        [JsonPropertyName("padstack")]
        public string Padstack { get; set; }

        [JsonPropertyName("pth_inside_courtyard")]
        public string PthInsideCourtyard { get; set; }

        [JsonPropertyName("shorting_items")]
        public string ShortingItems { get; set; }

        [JsonPropertyName("silk_edge_clearance")]
        public string SilkEdgeClearance { get; set; }

        [JsonPropertyName("silk_over_copper")]
        public string SilkOverCopper { get; set; }

        [JsonPropertyName("silk_overlap")]
        public string SilkOverlap { get; set; }

        [JsonPropertyName("skew_out_of_range")]
        public string SkewOutOfRange { get; set; }

        [JsonPropertyName("solder_mask_bridge")]
        public string SolderMaskBridge { get; set; }

        [JsonPropertyName("starved_thermal")]
        public string StarvedThermal { get; set; }

        [JsonPropertyName("text_height")]
        public string TextHeight { get; set; }

        [JsonPropertyName("text_thickness")]
        public string TextThickness { get; set; }

        [JsonPropertyName("through_hole_pad_without_hole")]
        public string ThroughHolePadWithoutHole { get; set; }

        [JsonPropertyName("too_many_vias")]
        public string TooManyVias { get; set; }

        [JsonPropertyName("track_angle")]
        public string TrackAngle { get; set; }

        [JsonPropertyName("track_dangling")]
        public string TrackDangling { get; set; }

        [JsonPropertyName("track_segment_length")]
        public string TrackSegmentLength { get; set; }

        [JsonPropertyName("track_width")]
        public string TrackWidth { get; set; }

        [JsonPropertyName("tracks_crossing")]
        public string TracksCrossing { get; set; }

        [JsonPropertyName("unconnected_items")]
        public string UnconnectedItems { get; set; }

        [JsonPropertyName("unresolved_variable")]
        public string UnresolvedVariable { get; set; }

        [JsonPropertyName("via_dangling")]
        public string ViaDangling { get; set; }

        [JsonPropertyName("zone_has_empty_net")]
        public string ZoneHasEmptyNet { get; set; }

        [JsonPropertyName("zones_intersect")]
        public string ZonesIntersect { get; set; }
    }
}
