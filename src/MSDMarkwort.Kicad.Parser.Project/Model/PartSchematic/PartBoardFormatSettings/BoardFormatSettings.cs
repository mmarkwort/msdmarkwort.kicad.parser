using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic.PartBoardFormatSettings
{
    public class BoardFormatSettings
    {
        [JsonPropertyName("field_delimiter")]
        public string FieldDelimiter { get; set; }

        [JsonPropertyName("keep_line_breaks")]
        public bool KeepLineBreaks { get; set; }

        [JsonPropertyName("keep_tabs")]
        public bool KeepTabs { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ref_delimiter")]
        public string RefDelimiter { get; set; }

        [JsonPropertyName("ref_range_delimiter")]
        public string RefRangeDelimiter { get; set; }

        [JsonPropertyName("string_delimiter")]
        public string StringDelimiter { get; set; }
    }
}
