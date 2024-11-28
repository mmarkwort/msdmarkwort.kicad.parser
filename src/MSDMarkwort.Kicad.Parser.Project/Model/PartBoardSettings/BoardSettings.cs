using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartIpc2581;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings
{
    public class BoardSettings
    {
        [JsonPropertyName("3dviewports")]
        public Viewport3D[] Viewports3D { get; set; } = Array.Empty<Viewport3D>();

        [JsonPropertyName("design_settings")]
        public DesignSettings DesignSettings { get; set; } = new DesignSettings();

        [JsonPropertyName("ipc2581")]
        public Ipc2581 Ipc2581 { get; set; } = new Ipc2581();

        [JsonPropertyName("layer_pairs")]
        public List<string> LayerPairs { get; set; } = new List<string>();

        [JsonPropertyName("layer_presets")]
        public List<string> LayerPresets { get; set; } = new List<string>();

        [JsonPropertyName("viewports")]
        public List<string> Viewports { get; set; } = new List<string>();
    }
}
