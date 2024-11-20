using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad;
using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartVia
{
    public class Via
    {
        [KicadElement("at")]
        public PositionAt Position { get; set; } = new PositionAt();

        [KicadElement("size")]
        public double Size { get; set; }

        [KicadElement("drill")]
        public double Drill { get; set; }

        [KicadElement("free")]
        public bool Free { get; set; }

        [KicadElement("layers")]
        public List<string> Layers { get; set; } = new List<string>();

        [KicadElement("locked")]
        public bool Locked { get; set; }

        [KicadElement("teardrops")]
        public Teardrops Teardrops { get; set; } = new Teardrops();

        [KicadElement("net")]
        public int Net { get; set; } = -1;

        [KicadElement("uuid")]
        public Guid Uuid { get; set; }
    }
}
