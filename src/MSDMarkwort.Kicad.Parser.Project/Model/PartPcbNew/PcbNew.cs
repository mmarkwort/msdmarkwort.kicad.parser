using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartPcbNew.PartLastPaths;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartPcbNew
{
    public class PcbNew
    {
        [JsonPropertyName("last_paths")]
        public LastPaths LastPaths { get; set; } = new LastPaths();

        [JsonPropertyName("page_layout_descr_file")]
        public string PageLayoutDescrFile { get; set; }
    }
}
