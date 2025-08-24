using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public enum HatchType
    {
        None,
        Edge,
        Full
    }

    public class Hatch
    {
        [KicadParameter(0)]
        public HatchType Type { get; set; }

        [KicadParameter(1)]
        public double Width { get; set; }
    }
}
