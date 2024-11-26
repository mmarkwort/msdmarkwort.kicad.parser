using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Model.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartLibFootprint;

namespace MSDMarkwort.Kicad.Parser.PcbNew
{
    public class FootprintLibParserRootModel : KicadRootModel<LibFootprint>
    {
        [KicadParserComplexSymbol("footprint")]
        [KicadParserComplexSymbol("module")]
        public override LibFootprint Root { get; set; } = new LibFootprint();
    }

    public class FootprintLibParser : KicadBaseParser<LibFootprint, FootprintLibParserRootModel>
    {
        private static readonly TypeCache StaticTypeCache = new TypeCache();

        protected int MinimumSupportedVersion = 6;

        static FootprintLibParser()
        {
            StaticTypeCache.LoadCache(new[] { typeof(FootprintLibParser).Assembly, typeof(Font).Assembly });
        }

        public FootprintLibParser() : base(StaticTypeCache)
        {
        }

        protected override bool CheckVersion(LibFootprint instance)
        {
            return true;
        }
    }
}
