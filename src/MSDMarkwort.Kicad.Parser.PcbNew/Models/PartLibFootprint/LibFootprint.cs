using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartLibFootprint
{
    public class LibFootprint : Footprint
    {
        [KicadParserSymbol("version")]
        public int Version { get; set; }

        [KicadParserSymbol("generator")]
        public string Generator { get; set; }

        [KicadParserSymbol("generator_version")]
        public string GeneratorVersion { get; set; }
    }
}
