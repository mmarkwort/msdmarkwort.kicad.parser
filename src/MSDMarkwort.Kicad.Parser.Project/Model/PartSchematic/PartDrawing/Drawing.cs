using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic.PartDrawing
{
    public class Drawing
    {
        [JsonPropertyName("dashed_lines_dash_length_ratio")]
        public double DashedLinesDashLengthRatio { get; set; }

        [JsonPropertyName("dashed_lines_gap_length_ratio")]
        public double DashedLinesGapLengthRatio { get; set; }

        [JsonPropertyName("default_bus_thickness")]
        public double DefaultBusThickness { get; set; }

        [JsonPropertyName("default_junction_size")]
        public double DefaultJunctionSize { get; set; }

        [JsonPropertyName("default_line_thickness")]
        public double DefaultLineThickness { get; set; }

        [JsonPropertyName("default_text_size")]
        public double DefaultTextSize { get; set; }

        [JsonPropertyName("default_wire_thickness")]
        public double DefaultWireThickness { get; set; }

        [JsonPropertyName("field_names")]
        public List<string> FieldNames { get; set; } = new List<string>();

        [JsonPropertyName("intersheets_ref_own_page")]
        public bool IntersheetsRefOwnPage { get; set; }

        [JsonPropertyName("intersheets_ref_prefix")]
        public string IntersheetsRefPrefix { get; set; }

        [JsonPropertyName("intersheets_ref_short")]
        public bool IntersheetsRefShort { get; set; }

        [JsonPropertyName("intersheets_ref_show")]
        public bool IntersheetsRefShow { get; set; }

        [JsonPropertyName("intersheets_ref_suffix")]
        public string IntersheetsRefSuffix { get; set; }

        [JsonPropertyName("junction_size_choice")]
        public int JunctionSizeChoice { get; set; }

        [JsonPropertyName("label_size_ratio")]
        public double LabelSizeRatio { get; set; }

        [JsonPropertyName("operating_point_overlay_i_precision")]
        public int OperatingPointOverlayIPrecision { get; set; }

        [JsonPropertyName("operating_point_overlay_i_range")]
        public string OperatingPointOverlayIRange { get; set; }

        [JsonPropertyName("operating_point_overlay_v_precision")]
        public int OperatingPointOverlayVPrecision { get; set; }

        [JsonPropertyName("operating_point_overlay_v_range")]
        public string OperatingPointOverlayVRange { get; set; }

        [JsonPropertyName("overbar_offset_ratio")]
        public double OverbarOffsetRatio { get; set; }

        [JsonPropertyName("pin_symbol_size")]
        public double PinSymbolSize { get; set; }

        [JsonPropertyName("text_offset_ratio")]
        public double TextOffsetRatio { get; set; }
    }
}
