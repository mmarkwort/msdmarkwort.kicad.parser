using MSDMarkwort.Kicad.Parser.Base.Attributes;
using System;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartBus;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartBusEntry;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartJunction;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartLibSymbols;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartWire;
using MSDMarkwort.Kicad.Parser.EESchema.PartLabel;
using MSDMarkwort.Kicad.Parser.EESchema.PartText;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartInstances;
using MSDMarkwort.Kicad.Parser.Model.Common;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartNoConnect;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartShapes;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartHierarchicalLabel;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartImage;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSheet;
using MSDMarkwort.Kicad.Parser.EESchema.PartTextBox;
using MSDMarkwort.Kicad.Parser.EESchema.PartGlobalLabel;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartKicadSch
{
    public class KicadSch
    {
        [KicadParserSymbol("version")]
        public int Version { get; set; }

        [KicadParserSymbol("generator")]
        public string Generator { get; set; }

        [KicadParserSymbol("generator_version")]
        public string GeneratorVersion { get; set; }

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserSymbol("paper")]
        public string PaperSize { get; set; }

        [KicadParserComplexSymbol("title_block")]
        public TitleBlock TitleBlock { get; set; } = new TitleBlock();

        [KicadParserComplexSymbol("lib_symbols")]
        public LibSymbols LibSymbols { get; set; } = new LibSymbols();

        [KicadParserList("symbol", KicadParserListAddType.Complex)]
        public SymbolCollection Symbols { get; set; } = new SymbolCollection();

        [KicadParserList("text_box", KicadParserListAddType.Complex)]
        public TextBoxCollection TextBoxes { get; set; } = new TextBoxCollection();

        [KicadParserList("text", KicadParserListAddType.Complex)]
        public TextCollection Texts { get; set; } = new TextCollection();

        [KicadParserList("polyline", KicadParserListAddType.Complex)]
        public PolylineCollection Polylines { get; set; } = new PolylineCollection();

        [KicadParserList("rectangle", KicadParserListAddType.Complex)]
        public RectangleCollection Rectangles { get; set; } = new RectangleCollection();

        [KicadParserList("circle", KicadParserListAddType.Complex)]
        public CircleCollection Circles { get; set; } = new CircleCollection();

        [KicadParserList("arc", KicadParserListAddType.Complex)]
        public ArcCollection Arcs { get; set; } = new ArcCollection();

        [KicadParserList("junction", KicadParserListAddType.Complex)]
        public JunctionCollection Junctions { get; set; } = new JunctionCollection();

        [KicadParserList("no_connect", KicadParserListAddType.Complex)]
        public NoConnectCollection NoConnect { get; set; } = new NoConnectCollection();

        [KicadParserList("bus_entry", KicadParserListAddType.Complex)]
        public BusEntryCollection BusEntry { get; set; } = new BusEntryCollection();

        [KicadParserList("bus", KicadParserListAddType.Complex)]
        public BusCollection Bus { get; set; } = new BusCollection();

        [KicadParserList("wire", KicadParserListAddType.Complex)]
        public WireCollection Wires { get; set; } = new WireCollection();

        [KicadParserList("hierarchical_label", KicadParserListAddType.Complex)]
        public HierarchicalLabelCollection HierarchicalLabels { get; set; } = new HierarchicalLabelCollection();

        [KicadParserList("label", KicadParserListAddType.Complex)]
        public LabelCollection Labels { get; set; } = new LabelCollection();

        [KicadParserList("global_label", KicadParserListAddType.Complex)]
        public GlobalLabelCollection GlobalLabels { get; set; } = new GlobalLabelCollection();

        [KicadParserList("sheet", KicadParserListAddType.Complex)]
        public SheetCollection Sheets { get; set; } = new SheetCollection();

        [KicadParserList("sheet_instances", KicadParserListAddType.Complex)]
        public SheetInstanceCollection SheetInstances { get; set; } = new SheetInstanceCollection();

        [KicadParserList("symbol_instances", KicadParserListAddType.Complex)]
        public SheetInstanceCollection SymbolInstances { get; set; } = new SheetInstanceCollection();

        [KicadParserSymbol("embedded_fonts")]
        public bool EmbeddedFonts { get; set; }

        [KicadParserList("image", KicadParserListAddType.Complex)]
        public ImageCollection Images { get; set; } = new ImageCollection();
    }
}
