using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic.PartBomSettings.PartFields
{
    public class Fields
    {
        [JsonPropertyName("group_by")]
        public bool GroupBy { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("show")]
        public bool Show { get; set; }
    }
}
