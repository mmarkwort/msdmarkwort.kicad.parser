using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad.PartPadStack
{
    public class PadStackLayer
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParserSymbol("shape")]
        public string Shape { get; set; }

        [KicadParserComplexSymbol("size")]
        public Size Size { get; set; } = new Size();

        [KicadParserSymbol("roundrect_rratio")]
        public double RoundRectRatio { get; set; }

        [KicadParserSymbol("chamfer_ratio")]
        public double ChamferRatio { get; set; }

        [KicadParserList("chamfer", KicadParserListAddType.FromParameters)]
        public List<string> Chamfers { get; set; } = new List<string>();
    }
}
