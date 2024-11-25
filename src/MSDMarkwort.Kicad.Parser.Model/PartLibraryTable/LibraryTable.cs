using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.PartLib;

namespace MSDMarkwort.Kicad.Parser.Model.PartLibraryTable
{
    public class LibraryTable
    {
        [KicadParserSymbol("version")]
        public int Version { get; set; }

        [KicadParserList("lib", KicadParserListAddType.Complex)]
        public LibCollection Libraries { get; set; } = new LibCollection();
    }
}
