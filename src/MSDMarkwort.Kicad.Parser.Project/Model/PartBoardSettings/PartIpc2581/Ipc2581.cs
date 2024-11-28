using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartIpc2581
{
    public class Ipc2581
    {
        [JsonPropertyName("dist")]
        public string Dist { get; set; }

        [JsonPropertyName("distpn")]
        public string DistPn { get; set; }

        [JsonPropertyName("internal_id")]
        public string InternalId { get; set; }

        [JsonPropertyName("mfg")]
        public string Mfg { get; set; }

        [JsonPropertyName("mpn")]
        public string Mpn { get; set; }
    }
}
