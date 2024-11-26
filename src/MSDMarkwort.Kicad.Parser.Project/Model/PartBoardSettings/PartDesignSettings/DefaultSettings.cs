using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartDimensions;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartPads;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartZones;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings
{
    public class DefaultSettings
    {
        [JsonPropertyName("apply_defaults_to_fp_fields")]
        public bool ApplyDefaultsToFpFields { get; set; }

        [JsonPropertyName("apply_defaults_to_fp_shapes")]
        public bool ApplyDefaultsToFpShapes { get; set; }

        [JsonPropertyName("apply_defaults_to_fp_text")]
        public bool ApplyDefaultsToFpText { get; set; }

        [JsonPropertyName("board_outline_line_width")]
        public double BoardOutlineLineWidth { get; set; }

        [JsonPropertyName("copper_line_width")]
        public double CopperLineWidth { get; set; }

        [JsonPropertyName("copper_text_italic")]
        public bool CopperTextItalic { get; set; }

        [JsonPropertyName("copper_text_size_h")]
        public double CopperTextSizeH { get; set; }

        [JsonPropertyName("copper_text_size_v")]
        public double CopperTextSizeV { get; set; }

        [JsonPropertyName("copper_text_thickness")]
        public double CopperTextThickness { get; set; }

        [JsonPropertyName("copper_text_upright")]
        public bool CopperTextUpright { get; set; }

        [JsonPropertyName("courtyard_line_width")]
        public double CourtyardLineWidth { get; set; }

        [JsonPropertyName("dimension_precision")]
        public int DimensionPrecision { get; set; }

        [JsonPropertyName("dimension_units")]
        public int DimensionUnits { get; set; }

        [JsonPropertyName("dimensions")]
        public Dimensions Dimensions { get; set; } = new Dimensions();

        [JsonPropertyName("fab_line_width")]
        public double FabLineWidth { get; set; }

        [JsonPropertyName("fab_text_italic")]
        public bool FabTextItalic { get; set; }

        [JsonPropertyName("fab_text_size_h")]
        public double FabTextSizeH { get; set; }

        [JsonPropertyName("fab_text_size_v")]
        public double FabTextSizeV { get; set; }

        [JsonPropertyName("fab_text_thickness")]
        public double FabTextThickness { get; set; }

        [JsonPropertyName("fab_text_upright")]
        public bool FabTextUpright { get; set; }

        [JsonPropertyName("other_line_width")]
        public double OtherLineWidth { get; set; }

        [JsonPropertyName("other_text_italic")]
        public bool OtherTextItalic { get; set; }

        [JsonPropertyName("other_text_size_h")]
        public double OtherTextSizeH { get; set; }

        [JsonPropertyName("other_text_size_v")]
        public double OtherTextSizeV { get; set; }

        [JsonPropertyName("other_text_thickness")]
        public double OtherTextThickness { get; set; }

        [JsonPropertyName("other_text_upright")]
        public bool OtherTextUpright { get; set; }

        [JsonPropertyName("pads")]
        public Pads Pads { get; set; } = new Pads();

        [JsonPropertyName("silk_line_width")]
        public double SilkLineWidth { get; set; }

        [JsonPropertyName("silk_text_italic")]
        public bool SilkTextItalic { get; set; }

        [JsonPropertyName("silk_text_size_h")]
        public double SilkTextSizeH { get; set; }

        [JsonPropertyName("silk_text_size_v")]
        public double SilkTextSizeV { get; set; }

        [JsonPropertyName("silk_text_thickness")]
        public double SilkTextThickness { get; set; }

        [JsonPropertyName("silk_text_upright")]
        public bool SilkTextUpright { get; set; }

        [JsonPropertyName("zones")]
        public Zones Zones { get; set; } = new Zones();
    }
}
