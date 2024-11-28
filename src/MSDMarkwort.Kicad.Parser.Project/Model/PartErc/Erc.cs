using System.Collections.Generic;
using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartCommon;
using MSDMarkwort.Kicad.Parser.Project.Model.PartErc.PartRuleSeverities;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartErc
{
    public class Erc
    {
        [JsonPropertyName("erc_exclusions")]
        public List<string> ErcExclusions { get; set; } = new List<string>();

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; } = new Meta();

        [JsonPropertyName("pin_map")]
        public List<List<int>> PinMap { get; set; } = new List<List<int>>();

        [JsonPropertyName("rule_severities")]
        public RuleSeverities RuleSeverities { get; set; } = new RuleSeverities();
    }
}
