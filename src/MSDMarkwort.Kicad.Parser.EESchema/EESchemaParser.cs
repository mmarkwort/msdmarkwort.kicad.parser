using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartKicadSch;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema
{
    public class EESchemaParserRootModel : KicadRootModel<KicadSch>
    {
        [KicadParserComplexSymbol("kicad_sch")]
        public override KicadSch Root { get; set; } = new KicadSch();
    }

    public class EESchemaParser : KicadBaseParser<KicadSch, EESchemaParserRootModel>
    {
        private static readonly TypeCache StaticTypeCache = new TypeCache();

        protected int MinimumSupportedVersion = 20200829;

        static EESchemaParser()
        {
            StaticTypeCache.LoadCache(new[] { typeof(EESchemaParser).Assembly, typeof(Font).Assembly });
        }

        public EESchemaParser() : base(StaticTypeCache)
        {
        }

        protected override bool CheckVersion(KicadSch instance)
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
