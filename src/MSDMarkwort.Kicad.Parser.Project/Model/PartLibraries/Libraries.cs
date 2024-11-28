using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartLibraries
{
    public class Libraries
    {
        [JsonPropertyName("pinned_footprint_libs")]
        public List<string> PinnedFootprintLibs { get; set; } = new List<string>();

        [JsonPropertyName("pinned_symbol_libs")]
        public List<string> PinnedSymbolLibs { get; set; } = new List<string>();
    }
}
