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
    }
}
