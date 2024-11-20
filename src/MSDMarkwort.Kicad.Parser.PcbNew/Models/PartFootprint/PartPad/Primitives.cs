using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad
{
    public class Primitives
    {
        [KicadElement("gr_line")]
        public GrCollection<GrLine> GrLines { get; set; } = new GrCollection<GrLine>();

        [KicadElement("gr_rect")]
        public GrCollection<GrRect> GrRects { get; set; } = new GrCollection<GrRect>();

        [KicadElement("gr_poly")]
        public GrCollection<GrPoly> GrPolys { get; set; } = new GrCollection<GrPoly>();

        [KicadElement("gr_text")]
        public GrCollection<GrText> GrTexts { get; set; } = new GrCollection<GrText>();

        [KicadElement("gr_arc")]
        public GrCollection<GrArc> GrArcs { get; set; } = new GrCollection<GrArc>();

        [KicadElement("gr_circle")]
        public GrCollection<GrCircle> GrCircle { get; set; } = new GrCollection<GrCircle>();
    }
}
