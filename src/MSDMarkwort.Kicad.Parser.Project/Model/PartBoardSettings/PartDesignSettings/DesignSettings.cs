using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartDiffPairDimensions;
using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartRuleSeverities;
using MSDMarkwort.Kicad.Parser.Project.Model.PartCommon;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartDefaults;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartRules;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartDefaults.PartTearDropOptions;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartDefaults.PartTearDropParameters;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartTuningPatternSettings;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartViaDimensions;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings
{
    public class DesignSettings
    {
        [JsonPropertyName("defaults")]
        public DefaultSettings DefaultSettings { get; set; } = new DefaultSettings ();

        [JsonPropertyName("diff_pair_dimensions")]
        public List<DiffPairDimensions> DiffPairDimensions { get; set; } = new List<DiffPairDimensions>();

        [JsonPropertyName("drc_exclusions")]
        public List<string> DrcExclusions { get; set; } = new List<string>();

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; } = new Meta();

        [JsonPropertyName("rule_severities")]
        public RuleSeverities RuleSeverities { get; set; } = new RuleSeverities();

        [JsonPropertyName("rule_severitieslegacy_courtyards_overlap")]
        public bool RuleSeveritiesLegacyCourtyardsOverlap { get; set; }

        [JsonPropertyName("rule_severitieslegacy_no_courtyard_defined")]
        public bool RuleSeveritiesLegacyNoCourtyardDefined { get; set; }

        [JsonPropertyName("rules")]
        public Rules Rules { get; set; } = new Rules();

        [JsonPropertyName("teardrop_options")]
        public List<TearDropOptions> TearDropOptions { get; set; } = new List<TearDropOptions>();

        [JsonPropertyName("teardrop_parameters")]
        public List<TearDropParameters> TearDropParameters { get; set; } = new List<TearDropParameters>();

        [JsonPropertyName("track_widths")]
        public List<double> TrackWidths { get; set; } = new List<double>();

        [JsonPropertyName("tuning_pattern_settings")]
        public TuningPatternSettings TuningPatternSettings { get; set; } = new TuningPatternSettings();

        [JsonPropertyName("via_dimensions")]
        public List<ViaDimensions> ViaDimensions { get; set; } = new List<ViaDimensions>();

        [JsonPropertyName("zones_allow_external_fillets")]
        public bool ZonesAllowExternalFillets { get; set; }

        [JsonPropertyName("zones_use_no_outline")]
        public bool ZonesUseNoOutline { get; set; }
    }
}
