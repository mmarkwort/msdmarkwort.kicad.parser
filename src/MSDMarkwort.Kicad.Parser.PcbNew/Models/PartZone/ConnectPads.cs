using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class ConnectPads
    {
        [KicadParameter(0)]
        public bool Connect { get; set; }

        [KicadParserSymbol("clearance")]
        public double Clearance { get; set; }
    }
}
