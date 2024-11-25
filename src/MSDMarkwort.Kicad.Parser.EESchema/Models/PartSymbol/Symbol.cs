using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartInstances;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartInstances.PartProject;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartPin;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartProperty;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartShapes;
using System;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol
{
    public class Symbol
    {
        [KicadParameter(0)]
        public string Name  { get; set; }

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserSymbol("lib_id")]
        public string LibId { get; set; }

        [KicadParserSymbol("pin_numbers")]
        public string PinNumbers { get; set; }

        [KicadParserSymbol("power", KicadParserSymbolSetType.ImplicitBoolTrue)]
        public bool IsPower { get; set; }

        [KicadParserComplexSymbol("pin_names")]
        public PinNames PinNames { get; set; } = new PinNames();

        [KicadParserSymbol("exclude_from_sim")]
        public bool ExcludeFromSim { get; set; }

        [KicadParserSymbol("unit")]
        public int Unit { get; set; }

        [KicadParserSymbol("in_bom")]
        public bool InBom { get; set; }

        [KicadParserSymbol("on_board")]
        public bool OnBoard { get; set; }

        [KicadParserSymbol("dnp")]
        public bool Dnp { get; set; }

        [KicadParserList("polyline", KicadParserListAddType.Complex)]
        public PolylineCollection Polylines { get; set; } = new PolylineCollection();

        [KicadParserList("rectangle", KicadParserListAddType.Complex)]
        public RectangleCollection Rectangles { get; set; } = new RectangleCollection();

        [KicadParserList("circle", KicadParserListAddType.Complex)]
        public CircleCollection Circles { get; set; } = new CircleCollection();

        [KicadParserSymbol("embedded_fonts")]
        public bool EmbeddedFonts { get; set; }

        [KicadParserList("property", KicadParserListAddType.Complex)]
        public PropertyCollection Properties { get; set; } = new PropertyCollection();

        [KicadParserList("pin", KicadParserListAddType.Complex)]
        public PinCollection Pins { get; set; } = new PinCollection();

        [KicadParserList("symbol", KicadParserListAddType.Complex)]
        public SymbolCollection Symbols { get; set; } = new SymbolCollection();

        [KicadParserList("instances", KicadParserListAddType.Complex)]
        public InstanceCollection Instances { get; set; } = new InstanceCollection();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
