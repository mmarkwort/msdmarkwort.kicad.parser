using System.Text.Json.Serialization;

namespace MSDMarkwort.Kicad.Parser.Project.Model.PartBoardSettings
{
    public class Viewport3D
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("xx")]
        public double Xx { get; set; }

        [JsonPropertyName("xy")]
        public double Xy { get; set; }

        [JsonPropertyName("xz")]
        public double Xz { get; set; }

        [JsonPropertyName("xw")]
        public double Xw { get; set; }

        [JsonPropertyName("yx")]
        public double Yx { get; set; }

        [JsonPropertyName("yy")]
        public double Yy { get; set; }

        [JsonPropertyName("yz")]
        public double Yz { get; set; }

        [JsonPropertyName("yw")]
        public double Yw { get; set; }

        [JsonPropertyName("zx")]
        public double Zx { get; set; }

        [JsonPropertyName("zy")]
        public double Zy { get; set; }

        [JsonPropertyName("zz")]
        public double Zz { get; set; }

        [JsonPropertyName("zw")]
        public double Zw { get; set; }

        [JsonPropertyName("wx")]
        public double Wx { get; set; }

        [JsonPropertyName("wy")]
        public double Wy { get; set; }

        [JsonPropertyName("wz")]
        public double Wz { get; set; }

        [JsonPropertyName("ww")]
        public double Ww { get; set; }
    }
}
