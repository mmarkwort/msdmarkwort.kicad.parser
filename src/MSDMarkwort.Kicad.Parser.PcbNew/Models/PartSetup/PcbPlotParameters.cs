// ReSharper disable StringLiteralTypo

using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup
{
    public class PcbPlotParameters
    {
        [KicadElement("layerselection")]
        public string LayerSelection { get; set; }

        [KicadElement("plot_on_all_layers_selection")]
        public string PlotOnAllLayersSelection { get; set; }

        [KicadElement("disableapertmacros")]
        public bool DisableApertMacros { get; set; }

        [KicadElement("usegerberextensions")]
        public bool UseGerberExtensions { get; set; }

        [KicadElement("usegerberattributes")]
        public bool UseGerberAttributes { get; set; }

        [KicadElement("usegerberadvancedattributes")]
        public bool UseGerberAdvancedAttributes { get; set; }

        [KicadElement("creategerberjobfile")]
        public bool CreateGerberJobFile { get; set; }

        [KicadElement("dashed_line_dash_ratio")]
        public double DashedLineDashRatio { get; set; }

        [KicadElement("dashed_line_gap_ratio")]
        public double DashedLineGapRatio { get; set; }

        [KicadElement("svgprecision")]
        public int SvgPrecision { get; set; }

        [KicadElement("plotframeref")]
        public bool PlotFrameRef { get; set; }

        [KicadElement("viasonmask")]
        public bool ViasOnMask { get; set; }

        [KicadElement("mode")]
        public int Mode { get; set; }

        [KicadElement("useauxorigin")]
        public bool UseAuxOrigin { get; set; }

        [KicadElement("hpglpennumber")]
        public int HpglPenNumber { get; set; }

        [KicadElement("hpglpenspeed")]
        public int HpglPenSpeed { get; set; }

        [KicadElement("hpglpendiameter")]
        public double HpglPenDiameter { get; set; }

        [KicadElement("pdf_front_fp_property_popups")]
        public bool PdfFrontFpPropertyPopups { get; set; }

        [KicadElement("pdf_back_fp_property_popups")]
        public bool PdfBackFpPropertyPopups { get; set; }

        [KicadElement("pdf_metadata")]
        public bool PdfMetadata { get; set; }

        [KicadElement("dxfpolygonmode")]
        public bool DxfPolygonMode { get; set; }

        [KicadElement("dxfimperialunits")]
        public bool DxfImperialUnits { get; set; }

        [KicadElement("dxfusepcbnewfont")]
        public bool DxfUsePcbNewFont { get; set; }

        [KicadElement("psnegative")]
        public bool PsNegative { get; set; }

        [KicadElement("psa4output")]
        public bool Psa4Output { get; set; }

        [KicadElement("plotreference")]
        public bool PlotReference { get; set; }

        [KicadElement("plotvalue")]
        public bool PlotValue { get; set; }

        [KicadElement("plotfptext")]
        public bool PlotFpText { get; set; }

        [KicadElement("plotinvisibletext")]
        public bool PlotInvisibleText { get; set; }

        [KicadElement("sketchpadsonfab")]
        public bool SketchPadsOnFab { get; set; }

        [KicadElement("plotpadnumbers")]
        public bool PlotPadNumbers { get; set; }

        [KicadElement("hidednponfab")]
        public bool HideDnpOnFab { get; set; }

        [KicadElement("sketchdnponfab")]
        public bool SketchDnpOnFab { get; set; }

        [KicadElement("crossoutdnponfab")]
        public bool CrossOutDnpOnFab { get; set; }

        [KicadElement("subtractmaskfromsilk")]
        public bool SubtractMaskFromSilk { get; set; }

        [KicadElement("outputformat")]
        public int OutputFormat { get; set; }

        [KicadElement("mirror")]
        public bool Mirror { get; set; }

        [KicadElement("drillshape")]
        public int DrillShape { get; set; }

        [KicadElement("scaleselection")]
        public int ScaleSelection { get; set; }

        [KicadElement("outputdirectory")]
        public string OutputDirectory { get; set; }
    }
}
