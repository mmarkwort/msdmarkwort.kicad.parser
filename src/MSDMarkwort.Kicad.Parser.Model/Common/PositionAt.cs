using MSDMarkwort.Kicad.Parser.Base.Attributes;
using System.Globalization;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class PositionAt : Position
    {
        [KicadParameter(2)]
        public double Angle { get; set; }

        [KicadParameter(3)]
        public string Locked { get; set; }

        public override string ToString()
        {
            return $"{X.ToString(CultureInfo.InvariantCulture)}/{Y.ToString(CultureInfo.InvariantCulture)} ({Angle.ToString(CultureInfo.InvariantCulture)}°)";
        }
    }
}
