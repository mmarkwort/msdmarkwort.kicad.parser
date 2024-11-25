using MSDMarkwort.Kicad.Parser.Base.Attributes;

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
            return $"{Width}/{Height}";
        }
    }
}
