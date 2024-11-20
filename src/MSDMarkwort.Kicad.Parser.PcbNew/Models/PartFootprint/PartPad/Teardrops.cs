using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad
{
    public class Teardrops
    {
        [KicadElement("best_length_ratio")]
        public double BestLengthRatio { get; set; }

        [KicadElement("max_length")]
        public double MaxLength { get; set; }

        [KicadElement("best_width_ratio")]
        public double BestWidthRatio { get; set; }

        [KicadElement("max_width")]
        public double MaxWidth { get; set; }

        [KicadElement("curve_points")]
        public double CurvePoints { get; set; }

        [KicadElement("filter_ratio")]
        public double FilterRatio { get; set; }

        [KicadElement("enabled")]
        public bool Enabled { get; set; }

        [KicadElement("allow_two_segments")]
        public bool AllowTwoSegments { get; set; }

        [KicadElement("prefer_zone_connections")]
        public bool PreferZoneConnections { get; set; }
    }
}
