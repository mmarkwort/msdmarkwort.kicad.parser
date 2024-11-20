using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb;
using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad
{
    public class Pad
    {
        [KicadParameter(0)]
        public string PadNumber { get; set; }

        [KicadParameter(1)]
        public string PadType { get; set; }

        [KicadParameter(2)]
        public string Shape { get; set; }

        [KicadElement("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadElement("size")]
        public Size Size { get; set; } = new Size();

        [KicadElement("rect_delta")]
        public Size RectDelta { get; set; } = new Size();

        [KicadElement("drill")]
        public Drill Drill { get; set; } = new Drill();

        [KicadElement("layers")]
        public List<string> Layers { get; set; } = new List<string>();

        [KicadElement("remove_unused_layers")]
        public bool RemoveUnusedLayers { get; set; }

        [KicadElement("roundrect_rratio")]
        public double RoundRectRatio { get; set; }

        [KicadElement("net")]
        public Net Net { get; set; } = new Net();

        [KicadElement("pintype")]
        public string PinType { get; set; }

        [KicadElement("pinfunction")]
        public string PinFunction { get; set; }

        [KicadElement("solder_paste_margin_ratio")]
        public double SolderPasteMarginRatio { get; set; }

        [KicadElement("zone_connect")]
        public int ZoneConnect { get; set; }

        [KicadElement("thermal_bridge_width")]
        public double ThermalBridgeWidth { get; set; }

        [KicadElement("thermal_gap")]
        public double ThermalGap { get; set; }

        [KicadElement("thermal_bridge_angle")]
        public double ThermalBridgeAngle { get; set; }

        [KicadElement("options")]
        public Options Options { get; set; } = new Options();

        [KicadElement("primitives")]
        public Primitives Primitives { get; set; } = new Primitives();

        [KicadElement("solder_mask_margin")]
        public double SolderMaskMargin { get; set; }

        [KicadElement("clearance")]
        public double Clearance { get; set; }

        [KicadElement("uuid")]
        public Guid Uuid { get; set; }

        [KicadElement("teardrops")]
        public Teardrops Teardrops { get; set; } = new Teardrops();
    }
}
