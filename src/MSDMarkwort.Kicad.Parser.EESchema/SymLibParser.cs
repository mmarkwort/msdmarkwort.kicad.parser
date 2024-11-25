using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using MSDMarkwort.Kicad.Parser.EESchema.PartSymLib;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema
{
    public class SymLibParserRootModel : KicadRootModel<SymLib>
    {
        [KicadParserComplexSymbol("kicad_symbol_lib")]
        public override SymLib Root { get; set; } = new SymLib();
    }

    public class SymLibParser : KicadBaseParser<SymLib, SymLibParserRootModel>
    {
        private static readonly TypeCache StaticTypeCache = new TypeCache();

        protected int MinimumSupportedVersion = 20200829;

        static SymLibParser()
        {
            StaticTypeCache.LoadCache(new[] { typeof(SymLibParser).Assembly, typeof(Font).Assembly });
        }

        public SymLibParser() : base(StaticTypeCache)
        {
        }

        protected override bool CheckVersion(SymLib instance)
        {
            if (instance.Version < MinimumSupportedVersion)
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
