using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings
{
    public class DesignSettings
    {
        [JsonPropertyName("defaults")]
        public DefaultSettings DefaultSettings { get; set; } = new DefaultSettings ();
    }
}
