using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr;
using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartZone
{
    public class Zone
    {
        [KicadElement("layer")]
        public string Layer { get; set; }

        [KicadElement("layers")]
        public List<string> Layers { get; set; } = new List<string>();

        [KicadElement("net")]
        public int Net { get; set; } = -1;

        [KicadElement("net_name")]
        public string NetName { get; set; }

        [KicadElement("uuid")]
        public Guid Uuid { get; set; }

        [KicadElement("name")]
        public string Name { get; set; }

        [KicadElement("hatch")]
        public Hatch Hatch { get; set; } = new Hatch();

        [KicadElement("priority")]
        public int Priority { get; set; }

        [KicadElement("attr")]
        public Attr Attr { get; set; } = new Attr();

        [KicadElement("connect_pads")]
        public ConnectPads ConnectPads { get; set; } = new ConnectPads();

        [KicadElement("min_thickness")]
        public double MinThickness { get; set; }

        [KicadElement("filled_areas_thickness")]
        public bool FilledAreasThickness { get; set; }

        [KicadElement("keepout")]
        public Keepout Keepout { get; set; } = new Keepout();

        [KicadElement("placement")]
        public Placement Placement { get; set; } = new Placement();

        [KicadElement("fill")]
        public Fill Fill { get; set; } = new Fill();

        [KicadElement("polygon")]
        public Polygon Polygon { get; set; } = new Polygon();

        [KicadElement("filled_polygon")]
        public FilledPolygon FilledPolygon { get; set; } = new FilledPolygon();
    }
}
