using System.Collections.Generic;
using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartCommon;
using MSDMarkwort.Kicad.Parser.Project.Model.PartNetSettings.PartClasses;
using MSDMarkwort.Kicad.Parser.Project.Model.PartNetSettings.PartNetClassPattern;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartNetSettings
{
    public class NetSettings
    {
        [JsonPropertyName("classes")]
        public List<Classes> Classes { get; set; } = new List<Classes>();

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; } = new Meta();

        [JsonPropertyName("net_colors")]
        public List<string> NetColors { get; set; }

        [JsonPropertyName("netclass_assignments")]
        public List<string> NetclassAssignments { get; set; }

        [JsonPropertyName("netclass_patterns")]
        public List<NetClassPattern> NetClassPatterns { get; set; }
    }
}
