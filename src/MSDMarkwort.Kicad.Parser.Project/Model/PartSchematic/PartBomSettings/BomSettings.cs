using System.Collections.Generic;
using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic.PartBomSettings.PartFields;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic.PartBomSettings
{
    public class BomSettings
    {
        [JsonPropertyName("exclude_dnp")]
        public bool ExcludeDnp { get; set; }

        [JsonPropertyName("fields_ordered")]
        public List<Fields> FieldsOrdered { get; set; } = new List<Fields>();

        [JsonPropertyName("filter_string")]
        public string FilterString { get; set; }

        [JsonPropertyName("group_symbols")]
        public bool GroupSymbols { get; set; }

        [JsonPropertyName("include_excluded_from_bom")]
        public bool IncludeExcludedFromBom { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sort_asc")]
        public bool SortAsc { get; set; }

        [JsonPropertyName("sort_field")]
        public string SortField { get; set; }
    }
}
