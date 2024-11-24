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

        [KicadParserComplexSymbol("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadParserComplexSymbol("size")]
        public Size Size { get; set; } = new Size();

        [KicadParserComplexSymbol("rect_delta")]
        public Size RectDelta { get; set; } = new Size();

        [KicadParserComplexSymbol("drill")]
        public Drill Drill { get; set; } = new Drill();

        [KicadParserSymbol("layers")]
        public List<string> Layers { get; set; } = new List<string>();

        [KicadParserSymbol("remove_unused_layers")]
        public bool RemoveUnusedLayers { get; set; }

        [KicadParserSymbol("roundrect_rratio")]
        public double RoundRectRatio { get; set; }

        [KicadParserComplexSymbol("net")]
        public Net Net { get; set; } = new Net();

        [KicadParserSymbol("pintype")]
        public string PinType { get; set; }

        [KicadParserSymbol("pinfunction")]
        public string PinFunction { get; set; }

        [KicadParserSymbol("solder_paste_margin_ratio")]
        public double SolderPasteMarginRatio { get; set; }

        [KicadParserSymbol("zone_connect")]
        public int ZoneConnect { get; set; }

        [KicadParserSymbol("thermal_bridge_width")]
        public double ThermalBridgeWidth { get; set; }

        [KicadParserSymbol("thermal_gap")]
        public double ThermalGap { get; set; }

        [KicadParserSymbol("thermal_bridge_angle")]
        public double ThermalBridgeAngle { get; set; }

        [KicadParserComplexSymbol("options")]
        public Options Options { get; set; } = new Options();

        [KicadParserComplexSymbol("primitives")]
        public Primitives Primitives { get; set; } = new Primitives();

        [KicadParserSymbol("solder_mask_margin")]
        public double SolderMaskMargin { get; set; }

        [KicadParserSymbol("clearance")]
        public double Clearance { get; set; }

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserComplexSymbol("teardrops")]
        public Teardrops Teardrops { get; set; } = new Teardrops();
    }
}
