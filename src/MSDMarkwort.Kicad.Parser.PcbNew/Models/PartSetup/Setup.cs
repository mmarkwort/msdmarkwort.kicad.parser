using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup
{
    public class Setup
    {
        [KicadElement("stackup")]
        public Stackup Stackup { get; set; } = new Stackup();

        [KicadElement("tenting")]
        public Tenting Tenting { get; set; } = new Tenting();

        [KicadElement("aux_axis_origin")]
        public Position AuxAxisOrigin { get; set; } = new Position();

        [KicadElement("grid_origin")]
        public Position GridOrigin { get; set; } = new Position();

        [KicadElement("pad_to_mask_clearance")]
        public double PadToMaskClearance { get; set; }

        [KicadElement("allow_soldermask_bridges_in_footprints")]
        public bool AllowSolderMaskBridgesInFootprints { get; set; }

        [KicadElement("pcbplotparams")]
        public PcbPlotParameters PcbPlotParameters { get; set; } = new PcbPlotParameters();
    }
}
