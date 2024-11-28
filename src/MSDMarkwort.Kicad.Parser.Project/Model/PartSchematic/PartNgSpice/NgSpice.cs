using MSDMarkwort.Kicad.Parser.Project.Model.PartCommon;
using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic.PartNgSpice
{
    public class NgSpice
    {
        [JsonPropertyName("fix_include_paths")]
        public bool FixIncludePaths { get; set; }

        [JsonPropertyName("fix_passive_vals")]
        public bool FixPassiveVals { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; } = new Meta();

        [JsonPropertyName("model_mode")]
        public int ModelMode { get; set; }

        [JsonPropertyName("workbook_filename")]
        public string WorkbookFilename { get; set; }
    }
}
