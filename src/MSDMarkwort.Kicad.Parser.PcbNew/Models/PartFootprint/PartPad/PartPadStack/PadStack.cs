using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad.PartPadStack
{
    public class PadStack
    {
        [KicadParserSymbol("mode")]
        public string Mode { get; set; }

        [KicadParserList("layer", KicadParserListAddType.Complex)]
        public List<PadStackLayer> Layers { get; set; } = new List<PadStackLayer>();
    }
}
