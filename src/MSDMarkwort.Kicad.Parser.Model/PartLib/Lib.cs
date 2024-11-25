using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.PartLib
{
    public class Lib
    {
        [KicadParserSymbol("name")]
        public string Name { get; set; }

        [KicadParserSymbol("type")]
        public string Type { get; set; }

        [KicadParserSymbol("uri")]
        public string Uri { get; set; }

        [KicadParserSymbol("options")]
        public string Options { get; set; }

        [KicadParserSymbol("descr")]
        public string Description { get; set; }
    }
}
