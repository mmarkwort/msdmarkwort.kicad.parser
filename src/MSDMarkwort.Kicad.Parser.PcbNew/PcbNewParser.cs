using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using MSDMarkwort.Kicad.Parser.Base.Parser.SExpression.Models;
using MSDMarkwort.Kicad.Parser.Model.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartLayers;

namespace MSDMarkwort.Kicad.Parser.PcbNew
{
    public class PcbParserRootModel : KicadRootModel<KicadPcb>
    {
        [KicadParserComplexSymbol("kicad_pcb")]
        public override KicadPcb Root { get; set; } = new KicadPcb();
    }

    public class PcbNewParser : KicadBaseParser<KicadPcb, PcbParserRootModel>
    {
        private static readonly TypeCache StaticTypeCache = new TypeCache();

        protected int MinimumSupportedVersion = 20200829;

        static PcbNewParser()
        {
            StaticTypeCache.LoadCache(new []{ typeof(PcbNewParser).Assembly, typeof(Font).Assembly });
        }

        public PcbNewParser() : base(StaticTypeCache)
        {
        }

        protected override string[] UnexpectedClosingBracketsIndicators => new string[] { "extension_offset" };

        protected override bool CheckVersion(KicadPcb instance)
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

        protected override int HandleOverrideType(Type overrideType, object model, List<SExpr> containingList, int idxInList, SExprSymbol symbol, out object overrideModel, out Type overrideModelType)
        {
            if (model.GetType() == typeof(BoardLayers))
            {
                return HandleBoardLayers(model as BoardLayers, symbol, idxInList, out overrideModel, out overrideModelType);
            }

            return base.HandleOverrideType(overrideType, model, containingList, idxInList, symbol, out overrideModel, out overrideModelType);
        }

        private int HandleBoardLayers(BoardLayers boardLayers, SExprSymbol symbol, int idxInList, out object overrideModel, out Type overrideModelType)
        {
            var newLayer = new BoardLayer { Number = int.Parse(symbol.Value) };

            overrideModel = newLayer;
            overrideModelType = newLayer.GetType();
            symbol.Value = "layers";

            boardLayers.Layers.Add(newLayer);

            return idxInList;
        }
    }
}
