using System.Collections.Generic;
using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartCommon;
using MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic.PartBoardFormatSettings;
using MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic.PartBomSettings;
using MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic.PartDrawing;
using MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic.PartNgSpice;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartSchematic
{
    public class Schematic
    {
        [JsonPropertyName("annotate_start_num")]
        public int AnnotateStartNum { get; set; }

        [JsonPropertyName("bom_export_filename")]
        public string BomExportFilename { get; set; }

        [JsonPropertyName("bom_fmt_presets")]
        public List<string> BomFmtPresets { get; set; }

        [JsonPropertyName("bom_fmt_settings")]
        public BoardFormatSettings BoardFormatSettings { get; set; } = new BoardFormatSettings();

        [JsonPropertyName("bom_presets")]
        public List<string> BomPresets { get; set; } = new List<string>();

        [JsonPropertyName("bom_settings")]
        public BomSettings BomSettings { get; set; } = new BomSettings();

        [JsonPropertyName("connection_grid_size")]
        public double ConnectionGridSize { get; set; }

        [JsonPropertyName("drawing")]
        public Drawing Drawing { get; set; } = new Drawing();

        [JsonPropertyName("legacy_lib_dir")]
        public string LegacyLibDir { get; set; }

        [JsonPropertyName("legacy_lib_list")]
        public List<string> LegacyLibList { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; } = new Meta();

        [JsonPropertyName("net_format_name")]
        public string NetFormatName { get; set; }

        [JsonPropertyName("ngspice")]
        public NgSpice NgSpice { get; set; } = new NgSpice();

        [JsonPropertyName("page_layout_descr_file")]
        public string PageLayoutDescrFile { get; set; }

        [JsonPropertyName("plot_directory")]
        public string PlotDirectory { get; set; }

        [JsonPropertyName("space_save_all_events")]
        public bool SpaceSaveAllEvents { get; set; }

        [JsonPropertyName("spice_adjust_passive_values")]
        public bool SpiceAdjustPassiveValues { get; set; }

        [JsonPropertyName("spice_current_sheet_as_root")]
        public bool SpiceCurrentSheetAsRoot { get; set; }

        [JsonPropertyName("spice_external_command")]
        public string SpiceExternalCommand { get; set; }

        [JsonPropertyName("spice_model_current_sheet_as_root")]
        public bool SpiceModelCurrentSheetAsRoot { get; set; }

        [JsonPropertyName("spice_save_all_currents")]
        public bool SpiceSaveAllCurrents { get; set; }

        [JsonPropertyName("spice_save_all_dissipations")]
        public bool SpiceSaveAllDissipations { get; set; }

        [JsonPropertyName("spice_save_all_voltages")]
        public bool SpiceSaveAllVoltages { get; set; }

        [JsonPropertyName("subpart_first_id")]
        public int SubPartFirstId { get; set; }

        [JsonPropertyName("subpart_id_separator")]
        public int SubPartIdSeparator { get; set; }
    }
}
