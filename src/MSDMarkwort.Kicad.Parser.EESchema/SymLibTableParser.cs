using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using MSDMarkwort.Kicad.Parser.Model.Common;
using MSDMarkwort.Kicad.Parser.Model.PartLibraryTable;

namespace MSDMarkwort.Kicad.Parser.EESchema
{
    public class SymLibTableParserRootModel : KicadRootModel<LibraryTable>
    {
        [KicadParserComplexSymbol("sym_lib_table")]
        public override LibraryTable Root { get; set; } = new LibraryTable();
    }

    public class SymLibTableParser : KicadBaseParser<LibraryTable, SymLibTableParserRootModel>
    {
        private static readonly TypeCache StaticTypeCache = new TypeCache();

        protected int MinimumSupportedVersion = 6;

        static SymLibTableParser()
        {
            StaticTypeCache.LoadCache(new[] { typeof(SymLibTableParser).Assembly, typeof(Font).Assembly });
        }

        public SymLibTableParser() : base(StaticTypeCache)
        {
        }

        protected override bool CheckVersion(LibraryTable instance)
        {
            if (instance.Version != 0 && instance.Version < MinimumSupportedVersion)
            {
                Warnings.Add(new ParserWarning
                {
                    Warning = ParserWarnings.MaybeUnsupportedFileVersion,
                    Information = $"Version could not be supported: {instance.Version}",
                    LineNo = 0
                });

                return false;
            }

            return true;
        }
    }
}
