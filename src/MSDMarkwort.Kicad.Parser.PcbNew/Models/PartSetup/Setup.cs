using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup
{
    public class Setup
    {
        [KicadParserComplexSymbol("stackup")]
        public Stackup Stackup { get; set; } = new Stackup();

        [KicadParserComplexSymbol("tenting")]
        public Tenting Tenting { get; set; } = new Tenting();

        [KicadParserSymbol("aux_axis_origin")]
        public Position AuxAxisOrigin { get; set; } = new Position();

        [KicadParserSymbol("grid_origin")]
        public Position GridOrigin { get; set; } = new Position();

        [KicadParserSymbol("pad_to_mask_clearance")]
        public double PadToMaskClearance { get; set; }

        [KicadParserSymbol("pad_to_paste_clearance")]
        public double PadToPasteClearance { get; set; }

        [KicadParserSymbol("solder_mask_min_width")]
        public double SolderMaskMinWidth { get; set; }

        [KicadParserSymbol("allow_soldermask_bridges_in_footprints")]
        public bool AllowSolderMaskBridgesInFootprints { get; set; }

        [KicadParserComplexSymbol("pcbplotparams")]
        public PcbPlotParameters PcbPlotParameters { get; set; } = new PcbPlotParameters();
    }
}
