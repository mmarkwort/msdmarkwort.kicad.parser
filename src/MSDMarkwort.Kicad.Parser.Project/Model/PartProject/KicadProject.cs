using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartProject
{
    public class KicadProject
    {
        [JsonPropertyName("board")]
        public BoardSettings BoardSettings { get; set; } = new BoardSettings();
    }
}
