using MSDMarkwort.Kicad.Parser.Base.Attributes;
using System.Globalization;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Position
    {
        [KicadParameter(0)]
        public double X { get; set; }

        [KicadParameter(1)]
        public double Y { get; set; }

        public override string ToString()
        {
            return $"{X.ToString(CultureInfo.InvariantCulture)}/{Y.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
