using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad
{
    public class Primitives
    {
        [KicadParserList("gr_line", KicadParserListAddType.Complex)]
        public GrCollection<GrLine> GrLines { get; set; } = new GrCollection<GrLine>();

        [KicadParserList("gr_rect", KicadParserListAddType.Complex)]
        [KicadParserList("gr_bbox", KicadParserListAddType.Complex)]
        public GrCollection<GrRect> GrRects { get; set; } = new GrCollection<GrRect>();

        [KicadParserList("gr_poly", KicadParserListAddType.Complex)]
        public GrCollection<GrPoly> GrPolys { get; set; } = new GrCollection<GrPoly>();

        [KicadParserList("gr_text", KicadParserListAddType.Complex)]
        public GrCollection<GrText> GrTexts { get; set; } = new GrCollection<GrText>();

        [KicadParserList("gr_arc", KicadParserListAddType.Complex)]
        public GrCollection<GrArc> GrArcs { get; set; } = new GrCollection<GrArc>();

        [KicadParserList("gr_circle", KicadParserListAddType.Complex)]
        public GrCollection<GrCircle> GrCircle { get; set; } = new GrCollection<GrCircle>();
    }
}
