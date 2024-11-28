using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartLegacy.PartCommon;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartLegacy
{
    public class Legacy
    {
        [JsonPropertyName("common")]
        public Common Common { get; set; } = new Common();

    }
}
