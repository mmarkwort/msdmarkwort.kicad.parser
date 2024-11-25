using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartVia
{
    public class Via
    {
        [KicadParameter(0)]
        public string ViaType { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt Position { get; set; } = new PositionAt();

        [KicadParserSymbol("size")]
        public double Size { get; set; }

        [KicadParserSymbol("drill")]
        public double Drill { get; set; }

        [KicadParserSymbol("free")]
        public bool Free { get; set; }

        [KicadParserList("layers", KicadParserListAddType.FromParameters)]
        [KicadParserList("zone_layer_connections", KicadParserListAddType.FromParameters)]
        public List<string> Layers { get; set; } = new List<string>();

        [KicadParserSymbol("locked")]
        public bool Locked { get; set; }

        [KicadParserComplexSymbol("teardrops")]
        public Teardrops Teardrops { get; set; } = new Teardrops();

        [KicadParserSymbol("net")]
        public int Net { get; set; } = -1;

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserSymbol("tstamp")]
        public Guid TStamp { get; set; }

        [KicadParserSymbol("keep_end_layers", KicadParserSymbolSetType.ImplicitBoolTrue)]
        public bool KeepEndLayers { get; set; }

        [KicadParserSymbol("remove_unused_layers", KicadParserSymbolSetType.ImplicitBoolTrue)]
        public bool RemoveUnusedLayers { get; set; }

        [KicadParserList("tenting", KicadParserListAddType.FromParameters)]
        public List<string> Tenting { get; set; } = new List<string>();
    }
}
