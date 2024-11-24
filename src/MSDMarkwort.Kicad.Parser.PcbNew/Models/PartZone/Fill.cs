using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Fill
    {
        [KicadParameter(0)]
        public bool FillArea { get; set; }

        [KicadParserSymbol("thermal_gap")]
        public double ThermalGap { get; set; }

        [KicadParserSymbol("thermal_bridge_width")]
        public double ThermalBridgeWidth { get; set; }

        [KicadParserSymbol("smoothing")]
        public string Smoothing { get; set; }

        [KicadParserSymbol("radius")]
        public double Radius { get; set; }

        [KicadParserSymbol("island_removal_mode")]
        public int IslandRemovalMode { get; set; }

        [KicadParserSymbol("island_area_min")]
        public int IslandAreaMin { get; set; }

        [KicadParserSymbol("mode")]
        public string Mode { get; set; }

        [KicadParserSymbol("hatch_thickness")]
        public double HatchThickness { get; set; }

        [KicadParserSymbol("hatch_gap")]
        public double HatchGap { get; set; }

        [KicadParserSymbol("hatch_orientation")]
        public double HatchOrientation { get; set; }

        [KicadParserSymbol("hatch_border_algorithm")]
        public string HatchBorderAlgorithm { get; set; }

        [KicadParserSymbol("hatch_min_hole_area")]
        public double HatchMinHoleArea { get; set; }
    }
}
