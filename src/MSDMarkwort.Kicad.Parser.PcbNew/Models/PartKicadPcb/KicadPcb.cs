using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartDimension;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartProperty;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartImage;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartLayers;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSegment;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartVia;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone;
using MSDMarkwort.Kicad.Parser.PcbNew.PartGenerated;
using MSDMarkwort.Kicad.Parser.PcbNew.PartTarget;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb
{
    public class KicadPcb
    {
        [KicadParserSymbol("version")]
        public int Version { get; set; }

        [KicadParserSymbol("generator")]
        public string Generator { get; set; }

        [KicadParserSymbol("generator_version")]
        public string GeneratorVersion { get; set; }

        [KicadParserComplexSymbol("general")]
        public General General { get; set; } = new General();

        [KicadParserSymbol("paper")]
        public string PaperSize { get; set; }

        [KicadParserComplexSymbol("title_block")]
        public TitleBlock TitleBlock { get; set; } = new TitleBlock();

        [KicadParserComplexSymbol("layers")]
        public BoardLayers Layers { get; set; } = new BoardLayers();

        [KicadParserComplexSymbol("setup")]
        public Setup Setup { get; set; } = new Setup();

        [KicadParserList("net", KicadParserListAddType.Complex)]
        public NetCollection Nets { get; set; } = new NetCollection();

        [KicadParserList("footprint", KicadParserListAddType.Complex)]
        [KicadParserList("module", KicadParserListAddType.Complex)]
        public FootprintCollection Footprints { get; set; } = new FootprintCollection();

        [KicadParserList("gr_line", KicadParserListAddType.Complex)]
        public GrCollection<GrLine> GrLines { get; set; } = new GrCollection<GrLine>();

        [KicadParserList("gr_rect", KicadParserListAddType.Complex)]
        public GrCollection<GrRect> GrRects { get; set; } = new GrCollection<GrRect>();

        [KicadParserList("gr_poly", KicadParserListAddType.Complex)]
        public GrCollection<GrPoly> GrPolys { get; set; } = new GrCollection<GrPoly>();

        [KicadParserList("gr_text", KicadParserListAddType.Complex)]
        public GrCollection<GrText> GrTexts { get; set; } = new GrCollection<GrText>();

        [KicadParserList("gr_text_box", KicadParserListAddType.Complex)]
        public GrCollection<GrTextBox> GrTextBoxes { get; set; } = new GrCollection<GrTextBox>();

        [KicadParserList("gr_arc", KicadParserListAddType.Complex)]
        public GrCollection<GrArc> GrArc { get; set; } = new GrCollection<GrArc>();

        [KicadParserList("arc", KicadParserListAddType.Complex)]
        public GrCollection<GrArc> Arc { get; set; } = new GrCollection<GrArc>();

        [KicadParserList("gr_circle", KicadParserListAddType.Complex)]
        public GrCollection<GrCircle> GrCircle { get; set; } = new GrCollection<GrCircle>();

        [KicadParserList("gr_curve", KicadParserListAddType.Complex)]
        public GrCollection<GrCurve> GrCurve { get; set; } = new GrCollection<GrCurve>();

        [KicadParserList("image", KicadParserListAddType.Complex)]
        public ImageCollection Images { get; set; } = new ImageCollection();

        [KicadParserList("dimension", KicadParserListAddType.Complex)]
        public DimensionCollection Dimensions { get; set; } = new DimensionCollection();

        [KicadParserList("segment", KicadParserListAddType.Complex)]
        public SegmentCollection Segments { get; set; } = new SegmentCollection();

        [KicadParserList("via", KicadParserListAddType.Complex)]
        public ViaCollection Vias { get; set; } = new ViaCollection();

        [KicadParserList("zone", KicadParserListAddType.Complex)]
        public ZoneCollection Zones { get; set; } = new ZoneCollection();

        [KicadParserSymbol("embedded_fonts")]
        public bool EmbeddedFonts { get; set; }

        [KicadParserList("group", KicadParserListAddType.Complex)]
        public GroupCollection Groups { get; set; } = new GroupCollection();

        [KicadParserList("property", KicadParserListAddType.Complex)]
        public PropertyCollection Properties { get; set; } = new PropertyCollection();

        [KicadParserComplexSymbol("target")]
        public Target Target { get; set; } = new Target();

        [KicadParserList("generated", KicadParserListAddType.Complex)]
        public GeneratedCollection GeneratedItems { get; set; } = new GeneratedCollection();

        public override string ToString()
        {
            return $"{TitleBlock.Title} (Version: {Version})";
        }
    }
}
