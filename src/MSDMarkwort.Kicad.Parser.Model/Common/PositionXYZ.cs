using MSDMarkwort.Kicad.Parser.Base.Attributes;

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
            return $"{X}/{Y}/{Z}";
        }
    }
}
