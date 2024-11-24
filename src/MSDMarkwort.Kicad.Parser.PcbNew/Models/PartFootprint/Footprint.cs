﻿using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartFp;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartModel;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartProperty;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb;
using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint
{
    public class Footprint
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParserSymbol("locked")]
        public bool IsLocked { get; set; }

        [KicadParserSymbol("layer")]
        public string Layer { get; set; }

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadParserSymbol("descr")]
        public string Description { get; set; }

        [KicadParserSymbol("tags")]
        public string Tags { get; set; }

        [KicadParserList("property", KicadParserListAddType.Complex)]
        public PropertyCollection Properties { get; set; } = new PropertyCollection();

        [KicadParserSymbol("path")]
        public string Path { get; set; }

        [KicadParserSymbol("clearance")]
        public double Clearance { get; set; }

        [KicadParserSymbol("sheetname")]
        public string SheetName { get; set; }

        [KicadParserSymbol("sheetfile")]
        public string SheetFile { get; set; }

        [KicadParserSymbol("solder_paste_margin_ratio")]
        public double SolderPasteMarginRatio { get; set; }

        [KicadParserSymbol("solder_mask_margin")]
        public double SolderMaskMargin { get; set; }

        [KicadParserSymbol("solder_paste_margin")]
        public double SolderPasteMargin { get; set; }

        [KicadParserSymbol("attr")]
        public string Attr { get; set; }

        [KicadParserSymbol("net_tie_pad_groups")]
        public string NetTiePadGroups { get; set; }

        [KicadParserList("fp_line", KicadParserListAddType.Complex)]
        public FpCollection<FpLine> FpLines { get; set; } = new FpCollection<FpLine>();

        [KicadParserList("fp_rect", KicadParserListAddType.Complex)]
        public FpCollection<FpRect> FpRects { get; set; } = new FpCollection<FpRect>();

        [KicadParserList("fp_circle", KicadParserListAddType.Complex)]
        public FpCollection<FpCircle> FpCircles { get; set; } = new FpCollection<FpCircle>();

        [KicadParserList("fp_arc", KicadParserListAddType.Complex)]
        public FpCollection<FpArc> FpArcs { get; set; } = new FpCollection<FpArc>();

        [KicadParserList("fp_poly", KicadParserListAddType.Complex)]
        public FpCollection<FpPoly> FpPolys { get; set; } = new FpCollection<FpPoly>();

        [KicadParserList("fp_text", KicadParserListAddType.Complex)]
        public FpCollection<FpText> FpTexts { get; set; } = new FpCollection<FpText>();

        [KicadParserList("pad", KicadParserListAddType.Complex)]
        public PadCollection Pads { get; set; } = new PadCollection();

        [KicadParserSymbol("embedded_fonts")]
        public bool EmbeddedFonts { get; set; }

        [KicadParserComplexSymbol("model")]
        public Model Model { get; set; } = new Model();

        [KicadParserList("group", KicadParserListAddType.Complex)]
        public GroupCollection Groups { get; set; } = new GroupCollection();

        public override string ToString()
        {
            return Description;
        }
    }
}
