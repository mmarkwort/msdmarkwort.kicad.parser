using MSDMarkwort.Kicad.Parser.Base.Attributes;

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
            return $"{X}/{Y} ({Angle}°)";
        }
    }
}
