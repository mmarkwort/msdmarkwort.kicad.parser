using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartNetSettings.PartClasses
{
    public class Classes
    {
        [JsonPropertyName("bus_width")]
        public double BusWidth { get; set; }

        [JsonPropertyName("clearance")]
        public double Clearance { get; set; }

        [JsonPropertyName("diff_pair_gap")]
        public double DiffPairGap { get; set; }

        [JsonPropertyName("diff_pair_via_gap")]
        public double DiffPairViaGap { get; set; }

        [JsonPropertyName("diff_pair_width")]
        public double DiffPairWidth { get; set; }

        [JsonPropertyName("line_style")]
        public int LineStyle { get; set; }

        [JsonPropertyName("microvia_diameter")]
        public double MicroViaDiameter { get; set; }

        [JsonPropertyName("microvia_drill")]
        public double MicroViaDrill { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("pcb_color")]
        public string PcbColor { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("schematic_color")]
        public string SchematicColor { get; set; }

        [JsonPropertyName("track_width")]
        public double TrackWidth { get; set; }

        [JsonPropertyName("via_diameter")]
        public double ViaDiameter { get; set; }

        [JsonPropertyName("via_drill")]
        public double ViaDrill { get; set; }

        [JsonPropertyName("wire_width")]
        public double WireWidth { get; set; }
    }
}
