using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.PartGenerated
{
    public class Generated
    {
        [KicadParserSymbol("id")]
        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserSymbol("type")]
        public string Type { get; set; }
        
        [KicadParserSymbol("name")]
        public string Name { get; set; }

        [KicadParserSymbol("layer")]
        public string Layer { get; set; }

        [KicadParserComplexSymbol("base_line")]
        public Baseline BaseLine { get; set; } = new Baseline();

        [KicadParserComplexSymbol("base_line_coupled")]
        public Baseline BaseLineCoupled { get; set; } = new Baseline();

        [KicadParserSymbol("corner_radius_percent")]
        public double CornerRadiusPercent { get; set; }

        [KicadParserComplexSymbol("end")]
        public PositionProxy End { get; set; } = new PositionProxy();

        [KicadParserSymbol("initial_side")]
        public string InitialSide { get; set; }

        [KicadParserSymbol("last_diff_pair_gap")]
        public double LastDiffPairGap { get; set; }

        [KicadParserSymbol("last_netname")]
        public string LastNetname { get; set; }

        [KicadParserSymbol("last_status")]
        public string LastStatus { get; set; }

        [KicadParserSymbol("last_track_width")]
        public double LastTrackWidth { get; set; }

        [KicadParserSymbol("last_tuning")]
        public string LastTuning { get; set; }

        [KicadParserSymbol("min_amplitude")]
        public double MinAmplitude { get; set; }

        [KicadParserSymbol("max_amplitude")]
        public double MaxAmplitude { get; set; }

        [KicadParserSymbol("min_spacing")]
        public double MinSpacing { get; set; }

        [KicadParserComplexSymbol("origin")]
        public PositionProxy Origin { get; set; } = new PositionProxy();

        [KicadParserSymbol("override_custom_rules")]
        public bool OverrideCustomRules { get; set; }

        [KicadParserSymbol("rounded")]
        public bool Rounded { get; set; }

        [KicadParserSymbol("single_sided")]
        public bool SingleSided { get; set; }

        [KicadParserSymbol("target_length")]
        public double TargetLength { get; set; }

        [KicadParserSymbol("target_length_max")]
        public double TargetLengthMax { get; set; }

        [KicadParserSymbol("target_length_min")]
        public double TargetLengthMin { get; set; }

        [KicadParserSymbol("target_skew")]
        public double TargetSkew { get; set; }

        [KicadParserSymbol("target_skew_max")]
        public double TargetSkewMax { get; set; }

        [KicadParserSymbol("target_skew_min")]
        public double TargetSkewMin { get; set; }

        [KicadParserSymbol("tuning_mode")]
        public string TuningMode { get; set; }

        [KicadParserList("members", KicadParserListAddType.FromParameters)]
        public List<Guid> Members { get; set; } = new List<Guid>();
    }
}
