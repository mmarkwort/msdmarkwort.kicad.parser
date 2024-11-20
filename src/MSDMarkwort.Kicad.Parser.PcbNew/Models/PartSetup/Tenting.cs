using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup
{
    public class Tenting
    {
        [KicadParameter(0)]
        public bool TentViaFront { get; set; }

        [KicadParameter(1)]
        public bool TentViaBack { get; set; }
    }
}
