using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Zone
    {
        [KicadParserSymbol("layer")]
        public string Layer { get; set; }

        [KicadParserList("layers", KicadParserListAddType.FromParameters)]
        public List<string> Layers { get; set; } = new List<string>();

        [KicadParserSymbol("net")]
        public int Net { get; set; } = -1;

        [KicadParserSymbol("net_name")]
        public string NetName { get; set; }

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserSymbol("tstamp")]
        public Guid TStamp { get; set; }

        [KicadParserSymbol("name")]
        public string Name { get; set; }

        [KicadParserComplexSymbol("hatch")]
        public Hatch Hatch { get; set; } = new Hatch();

        [KicadParserSymbol("priority")]
        public int Priority { get; set; }

        [KicadParserComplexSymbol("attr")]
        public Attr Attr { get; set; } = new Attr();

        [KicadParserComplexSymbol("connect_pads")]
        public ConnectPads ConnectPads { get; set; } = new ConnectPads();

        [KicadParserSymbol("min_thickness")]
        public double MinThickness { get; set; }

        [KicadParserSymbol("filled_areas_thickness")]
        public bool FilledAreasThickness { get; set; }

        [KicadParserComplexSymbol("keepout")]
        public Keepout Keepout { get; set; } = new Keepout();

        [KicadParserComplexSymbol("placement")]
        public Placement Placement { get; set; } = new Placement();

        [KicadParserComplexSymbol("fill")]
        public Fill Fill { get; set; } = new Fill();

        [KicadParserComplexSymbol("polygon")]
        public Polygon Polygon { get; set; } = new Polygon();

        [KicadParserComplexSymbol("filled_polygon")]
        public FilledPolygon FilledPolygon { get; set; } = new FilledPolygon();
    }
}
