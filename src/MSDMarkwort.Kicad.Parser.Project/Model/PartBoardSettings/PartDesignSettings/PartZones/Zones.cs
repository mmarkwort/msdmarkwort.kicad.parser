using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings.PartZones
{
    public class Zones
    {
        [JsonPropertyName("45_degree_only")]
        public bool _45DegreeOnly { get; set; }

        [JsonPropertyName("min_clearance")]
        public double MinClearance { get; set; }
    }
}