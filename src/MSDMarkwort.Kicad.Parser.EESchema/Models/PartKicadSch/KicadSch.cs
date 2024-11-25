using MSDMarkwort.Kicad.Parser.Base.Attributes;
using System;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartJunction;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartLibSymbols;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartWire;
using MSDMarkwort.Kicad.Parser.EESchema.PartLabel;
using MSDMarkwort.Kicad.Parser.EESchema.PartText;

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

        [KicadParserList("text", KicadParserListAddType.Complex)]
        public TextCollection Texts { get; set; } = new TextCollection();

        [KicadParserList("junction", KicadParserListAddType.Complex)]
        public JunctionCollection Junctions { get; set; } = new JunctionCollection();

        [KicadParserList("wire", KicadParserListAddType.Complex)]
        public WireCollection Wires { get; set; } = new WireCollection();

        [KicadParserList("label", KicadParserListAddType.Complex)]
        public LabelCollection Labels { get; set; } = new LabelCollection();
    }
}
