using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartPcbNew.PartLastPaths
{
    public class LastPaths
    {
        [JsonPropertyName("gencad")]
        public string Gencad { get; set; }

        [JsonPropertyName("idf")]
        public string Idf { get; set; }

        [JsonPropertyName("netlist")]
        public string NetList { get; set; }

        [JsonPropertyName("plot")]
        public string Plot { get; set; }

        [JsonPropertyName("pos_files")]
        public string PosFiles { get; set; }

        [JsonPropertyName("specctra_dsn")]
        public string SpecctraDsn { get; set; }

        [JsonPropertyName("step")]
        public string Step { get; set; }

        [JsonPropertyName("svg")]
        public string Svg { get; set; }

        [JsonPropertyName("vmrl")]
        public string Vmrl { get; set; }

        [JsonPropertyName("vrml")]
        public string Vrml { get; set; }
    }
}
