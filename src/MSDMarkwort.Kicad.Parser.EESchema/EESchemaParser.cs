using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartKicadSch;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MSDMarkwort.Kicad.Parser.EESchema
{
    public class EESchemaParserRootModel : KicadRootModel<KicadSch>
    {
        [KicadParserComplexSymbol("kicad_pcb")]
        public override KicadSch Root { get; set; } = new KicadSch();
    }

    public class EESchemaParser : KicadBaseParser<KicadSch, EESchemaParserRootModel>
    {
        private static readonly TypeCache StaticTypeCache = new TypeCache();

        protected ReadOnlyCollection<int> SupportedVersions = new ReadOnlyCollection<int>(new List<int>()
        {
        });

        static EESchemaParser()
        {
            StaticTypeCache.LoadCache(typeof(EESchemaParser).Assembly);
        }

        protected override string[] UnexpectedClosingBracketsIndicators => new string[] { "offset" };

        public EESchemaParser() : base(StaticTypeCache)
        {
        }

        protected override bool CheckVersion(KicadSch instance)
        {
            return true;
        }
    }
}
