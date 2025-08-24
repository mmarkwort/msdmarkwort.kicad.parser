using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common.Enums;

namespace MSDMarkwort.Kicad.Parser.Model.PartLib
{
    public class Lib
    {
        [KicadParserSymbol("name")]
        public string Name { get; set; }

        [KicadParserSymbol("type")]
        public LibraryType Type { get; set; }

        [KicadParserSymbol("uri")]
        public string Uri { get; set; }

        [KicadParserSymbol("options")]
        public string Options { get; set; }

        [KicadParserSymbol("descr")]
        public string Description { get; set; }
    }
}
