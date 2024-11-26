using System;
using MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings.PartDesignSettings;
using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings
{
    public class BoardSettings
    {
        [JsonPropertyName("3dviewports")]
        public Viewport3D[] Viewports3D { get; set; } = Array.Empty<Viewport3D>();

        [JsonPropertyName("design_settings")]
        public DesignSettings DesignSettings { get; set; } = new DesignSettings();
    }
}
