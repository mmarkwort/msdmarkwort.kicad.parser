using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartNetSettings.PartNetClassPattern
{
    public class NetClassPattern
    {
        [JsonPropertyName("netclass")]
        public string NetClass { get; set; }

        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }
    }
}
