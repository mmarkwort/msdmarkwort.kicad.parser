using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
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

        [KicadElement("locked")]
        public bool IsLocked { get; set; }

        [KicadElement("layer")]
        public string Layer { get; set; }

        [KicadElement("uuid")]
        public Guid Uuid { get; set; }

        [KicadElement("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadElement("descr")]
        public string Description { get; set; }

        [KicadElement("tags")]
        public string Tags { get; set; }

        [KicadElement("property")]
        public PropertyCollection Properties { get; set; } = new PropertyCollection();

        [KicadElement("path")]
        public string Path { get; set; }

        [KicadElement("clearance")]
        public double Clearance { get; set; }

        [KicadElement("sheetname")]
        public string SheetName { get; set; }

        [KicadElement("sheetfile")]
        public string SheetFile { get; set; }

        [KicadElement("solder_paste_margin_ratio")]
        public double SolderPasteMarginRatio { get; set; }

        [KicadElement("solder_mask_margin")]
        public double SolderMaskMargin { get; set; }

        [KicadElement("solder_paste_margin")]
        public double SolderPasteMargin { get; set; }

        [KicadElement("attr")]
        public string Attr { get; set; }

        [KicadElement("net_tie_pad_groups")]
        public string NetTiePadGroups { get; set; }

        [KicadElement("fp_line")]
        public FpCollection<FpLine> FpLines { get; set; } = new FpCollection<FpLine>();

        [KicadElement("fp_rect")]
        public FpCollection<FpRect> FpRects { get; set; } = new FpCollection<FpRect>();

        [KicadElement("fp_circle")]
        public FpCollection<FpCircle> FpCircles { get; set; } = new FpCollection<FpCircle>();

        [KicadElement("fp_arc")]
        public FpCollection<FpArc> FpArcs { get; set; } = new FpCollection<FpArc>();

        [KicadElement("fp_poly")]
        public FpCollection<FpPoly> FpPolys { get; set; } = new FpCollection<FpPoly>();

        [KicadElement("fp_text")]
        public FpCollection<FpText> FpTexts { get; set; } = new FpCollection<FpText>();

        [KicadElement("pad")]
        public PadCollection Pads { get; set; } = new PadCollection();

        [KicadElement("embedded_fonts")]
        public bool EmbeddedFonts { get; set; }

        [KicadElement("model")]
        public Model Model { get; set; } = new Model();

        [KicadElement("group")]
        public GroupCollection Groups { get; set; } = new GroupCollection();

        public override string ToString()
        {
            return Description;
        }
    }
}
