using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartDimension;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartLayers;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSegment;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartVia;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb
{
    public class KicadPcb
    {
        [KicadElement("version")]
        public int Version { get; set; }

        [KicadElement("generator")]
        public string Generator { get; set; }

        [KicadElement("generator_version")]
        public string GeneratorVersion { get; set; }

        [KicadElement("general")]
        public General General { get; set; } = new General();

        [KicadElement("paper")]
        public string PaperSize { get; set; }

        [KicadElement("title_block")]
        public TitleBlock TitleBlock { get; set; } = new TitleBlock();

        [KicadElement("layers")]
        public BoardLayerCollection Layers { get; set; } = new BoardLayerCollection();

        [KicadElement("setup")]
        public Setup Setup { get; set; } = new Setup();

        [KicadElement("net")]
        public NetCollection Nets { get; set; } = new NetCollection();

        [KicadElement("footprint")]
        public FootprintCollection Footprints { get; set; } = new FootprintCollection();

        [KicadElement("gr_line")]
        public GrCollection<GrLine> GrLines { get; set; } = new GrCollection<GrLine>();

        [KicadElement("gr_rect")]
        public GrCollection<GrRect> GrRects { get; set; } = new GrCollection<GrRect>();

        [KicadElement("gr_poly")]
        public GrCollection<GrPoly> GrPolys { get; set; } = new GrCollection<GrPoly>();

        [KicadElement("gr_text")]
        public GrCollection<GrText> GrTexts { get; set; } = new GrCollection<GrText>();

        [KicadElement("gr_arc")]
        public GrCollection<GrArc> GrArc { get; set; } = new GrCollection<GrArc>();

        [KicadElement("arc")]
        public GrCollection<GrArc> Arc { get; set; } = new GrCollection<GrArc>();

        [KicadElement("gr_circle")]
        public GrCollection<GrCircle> GrCircle { get; set; } = new GrCollection<GrCircle>();

        [KicadElement("dimension")]
        public DimensionCollection Dimensions { get; set; } = new DimensionCollection();

        [KicadElement("segment")]
        public SegmentCollection Segments { get; set; } = new SegmentCollection();

        [KicadElement("via")]
        public ViaCollection Vias { get; set; } = new ViaCollection();

        [KicadElement("zone")]
        public ZoneCollection Zones { get; set; } = new ZoneCollection();

        [KicadElement("embedded_fonts")]
        public bool EmbeddedFonts { get; set; }

        [KicadElement("group")]
        public GroupCollection Groups { get; set; } = new GroupCollection();
    }
}
