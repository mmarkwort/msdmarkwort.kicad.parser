using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Fill
    {
        [KicadParameter(0)]
        public bool FillArea { get; set; }

        [KicadElement("thermal_gap")]
        public double ThermalGap { get; set; }

        [KicadElement("thermal_bridge_width")]
        public double ThermalBridgeWidth { get; set; }

        [KicadElement("smoothing")]
        public string Smoothing { get; set; }

        [KicadElement("radius")]
        public double Radius { get; set; }

        [KicadElement("island_removal_mode")]
        public int IslandRemovalMode { get; set; }

        [KicadElement("island_area_min")]
        public int IslandAreaMin { get; set; }
    }
}
