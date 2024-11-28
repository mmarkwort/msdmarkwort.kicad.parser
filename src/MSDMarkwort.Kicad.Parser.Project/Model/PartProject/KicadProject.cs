using System.Collections.Generic;
using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings;
using MSDMarkwort.Kicad.Parser.Project.Model.PartCommon;
using MSDMarkwort.Kicad.Parser.Project.Model.PartCvPcb;
using MSDMarkwort.Kicad.Parser.Project.Model.PartErc;
using MSDMarkwort.Kicad.Parser.Project.Model.PartLegacy;
using MSDMarkwort.Kicad.Parser.Project.Model.PartLibraries;
using MSDMarkwort.Kicad.Parser.Project.Model.PartNetSettings;
using MSDMarkwort.Kicad.Parser.Project.Model.PartPcbNew;
using MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartProject
{
    public class KicadProject
    {
        [JsonPropertyName("board")]
        public BoardSettings BoardSettings { get; set; } = new BoardSettings();

        [JsonPropertyName("boards")]
        public List<string> Boards { get; set; } = new List<string>();

        [JsonPropertyName("cvpcb")]
        public CvPcb CvPcb { get; set; } = new CvPcb();

        [JsonPropertyName("erc")]
        public Erc Erc { get; set; } = new Erc();

        [JsonPropertyName("legacy")]
        public Legacy Legacy { get; set; } = new Legacy();

        [JsonPropertyName("libraries")]
        public Libraries Libraries { get; set; } = new Libraries();

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; } = new Meta();

        [JsonPropertyName("net_settings")]
        public NetSettings NetSettings { get; set; } = new NetSettings();

        [JsonPropertyName("pcbnew")]
        public PcbNew PcbNew { get; set; } = new PcbNew();

        [JsonPropertyName("schematic")]
        public Schematic Schematic { get; set; } = new Schematic();

        [JsonPropertyName("sheets")]
        public List<List<string>> Sheets { get; set; } = new List<List<string>>();

        [JsonPropertyName("text_variables")]
        public object TextVariables { get; set; } = new object();
    }
}
