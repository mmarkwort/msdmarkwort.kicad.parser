using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class ExtensionOffset
    {
        [KicadParameter(0)]
        public double Offset { get; set; }

        [KicadParameter(1)]
        public string Alignment { get; set; }

        public override string ToString()
        {
            return $"{Offset} - {Alignment}";
        }
    }
}
