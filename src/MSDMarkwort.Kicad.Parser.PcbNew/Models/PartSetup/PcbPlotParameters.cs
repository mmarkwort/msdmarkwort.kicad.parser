// ReSharper disable StringLiteralTypo

using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup
{
    public class PcbPlotParameters
    {
        [KicadParserSymbol("layerselection")]
        public string LayerSelection { get; set; }

        [KicadParserSymbol("plot_on_all_layers_selection")]
        public string PlotOnAllLayersSelection { get; set; }

        [KicadParserSymbol("disableapertmacros")]
        public bool DisableApertMacros { get; set; }

        [KicadParserSymbol("usegerberextensions")]
        public bool UseGerberExtensions { get; set; }

        [KicadParserSymbol("usegerberattributes")]
        public bool UseGerberAttributes { get; set; }

        [KicadParserSymbol("usegerberadvancedattributes")]
        public bool UseGerberAdvancedAttributes { get; set; }

        [KicadParserSymbol("creategerberjobfile")]
        public bool CreateGerberJobFile { get; set; }

        [KicadParserSymbol("dashed_line_dash_ratio")]
        public double DashedLineDashRatio { get; set; }

        [KicadParserSymbol("dashed_line_gap_ratio")]
        public double DashedLineGapRatio { get; set; }

        [KicadParserSymbol("svguseinch")]
        public bool SvgUseInch { get; set; }

        [KicadParserSymbol("svgprecision")]
        public int SvgPrecision { get; set; }

        [KicadParserSymbol("excludeedgelayer")]
        public bool ExcludeEdgeLayer { get; set; }

        [KicadParserSymbol("linewidth")]
        public double LineWidth { get; set; }

        [KicadParserSymbol("plotframeref")]
        public bool PlotFrameRef { get; set; }

        [KicadParserSymbol("viasonmask")]
        public bool ViasOnMask { get; set; }

        [KicadParserSymbol("mode")]
        public int Mode { get; set; }

        [KicadParserSymbol("useauxorigin")]
        public bool UseAuxOrigin { get; set; }

        [KicadParserSymbol("hpglpennumber")]
        public int HpglPenNumber { get; set; }

        [KicadParserSymbol("hpglpenspeed")]
        public int HpglPenSpeed { get; set; }

        [KicadParserSymbol("hpglpendiameter")]
        public double HpglPenDiameter { get; set; }

        [KicadParserSymbol("pdf_front_fp_property_popups")]
        public bool PdfFrontFpPropertyPopups { get; set; }

        [KicadParserSymbol("pdf_back_fp_property_popups")]
        public bool PdfBackFpPropertyPopups { get; set; }

        [KicadParserSymbol("pdf_metadata")]
        public bool PdfMetadata { get; set; }

        [KicadParserSymbol("dxfpolygonmode")]
        public bool DxfPolygonMode { get; set; }

        [KicadParserSymbol("dxfimperialunits")]
        public bool DxfImperialUnits { get; set; }

        [KicadParserSymbol("dxfusepcbnewfont")]
        public bool DxfUsePcbNewFont { get; set; }

        [KicadParserSymbol("psnegative")]
        public bool PsNegative { get; set; }

        [KicadParserSymbol("psa4output")]
        public bool Psa4Output { get; set; }

        [KicadParserSymbol("plotreference")]
        public bool PlotReference { get; set; }

        [KicadParserSymbol("plotvalue")]
        public bool PlotValue { get; set; }

        [KicadParserSymbol("plotfptext")]
        public bool PlotFpText { get; set; }

        [KicadParserSymbol("plotinvisibletext")]
        public bool PlotInvisibleText { get; set; }

        [KicadParserSymbol("sketchpadsonfab")]
        public bool SketchPadsOnFab { get; set; }

        [KicadParserSymbol("plotpadnumbers")]
        public bool PlotPadNumbers { get; set; }

        [KicadParserSymbol("hidednponfab")]
        public bool HideDnpOnFab { get; set; }

        [KicadParserSymbol("sketchdnponfab")]
        public bool SketchDnpOnFab { get; set; }

        [KicadParserSymbol("crossoutdnponfab")]
        public bool CrossOutDnpOnFab { get; set; }

        [KicadParserSymbol("subtractmaskfromsilk")]
        public bool SubtractMaskFromSilk { get; set; }

        [KicadParserSymbol("outputformat")]
        public int OutputFormat { get; set; }

        [KicadParserSymbol("mirror")]
        public bool Mirror { get; set; }

        [KicadParserSymbol("drillshape")]
        public int DrillShape { get; set; }

        [KicadParserSymbol("scaleselection")]
        public int ScaleSelection { get; set; }

        [KicadParserSymbol("outputdirectory")]
        public string OutputDirectory { get; set; }
    }
}
