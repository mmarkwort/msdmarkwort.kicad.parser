using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Margin
    {
        [KicadParameter(0)]
        public double Left { get; set; }

        [KicadParameter(1)]
        public double Top { get; set; }

        [KicadParameter(2)]
        public double Right { get; set; }

        [KicadParameter(3)]
        public double Bottom { get; set; }
    }
}
