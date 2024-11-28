using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartLegacy.PartCommon
{
    public class Common
    {
        [JsonPropertyName("NetDir")]
        public string NetDir { get; set; }
    }
}
