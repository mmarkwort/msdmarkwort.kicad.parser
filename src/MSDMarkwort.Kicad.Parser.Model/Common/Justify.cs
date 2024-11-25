using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Justify
    {
        [KicadParameter(0)]
        public string HorizontalAlignment { get; set; }

        [KicadParameter(1)]
        public string VerticalAlignment { get; set; }

        [KicadParameter(2)]
        public string Mirror { get; set; }
    }
}
