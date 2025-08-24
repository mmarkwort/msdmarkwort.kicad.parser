using MSDMarkwort.Kicad.Parser.Base.Attributes;
using System.Globalization;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Size
    {
        [KicadParameter(0)]
        public double Width { get; set; }

        [KicadParameter(1)]
        public double Height { get; set; }

        public override string ToString()
        {
            return $"{Width.ToString(CultureInfo.InvariantCulture)}/{Height.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
