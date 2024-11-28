using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartCvPcb
{
    public class CvPcb
    {
        [JsonPropertyName("equivalence_files")]
        public List<string> EquivalenceFiles { get; set; } = new List<string>();
    }
}
