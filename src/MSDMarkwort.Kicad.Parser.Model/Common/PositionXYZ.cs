using MSDMarkwort.Kicad.Parser.Base.Attributes;
using System.Globalization;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class PositionXYZ
    {
        [KicadParameter(0)]
        public double X { get; set; }

        [KicadParameter(1)]
        public double Y { get; set; }

        [KicadParameter(2)]
        public double Z { get; set; }

        public override string ToString()
        {
            return $"{X.ToString(CultureInfo.InvariantCulture)}/{Y.ToString(CultureInfo.InvariantCulture)}/{Z.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
