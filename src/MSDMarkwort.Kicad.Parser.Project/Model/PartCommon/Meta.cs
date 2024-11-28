using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartCommon
{
    public class Meta
    {
        [JsonPropertyName("filename")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Filename { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}
