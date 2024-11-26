using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Model.Common;
using MSDMarkwort.Kicad.Parser.Model.PartLibraryTable;

namespace MSDMarkwort.Kicad.Parser.PcbNew
{
    public class FootprintLibTableParserRootModel : KicadRootModel<LibraryTable>
    {
        [KicadParserComplexSymbol("fp_lib_table")]
        public override LibraryTable Root { get; set; } = new LibraryTable();
    }

    public class FootprintLibTableParser : KicadBaseParser<LibraryTable, FootprintLibTableParserRootModel>
    {
        private static readonly TypeCache StaticTypeCache = new TypeCache();

        protected int MinimumSupportedVersion = 6;

        static FootprintLibTableParser()
        {
            StaticTypeCache.LoadCache(new[] { typeof(FootprintLibParser).Assembly, typeof(Font).Assembly });
        }

        public FootprintLibTableParser() : base(StaticTypeCache)
        {
        }

        protected override bool CheckVersion(LibraryTable instance)
        {
            return true;
        }
    }
}
