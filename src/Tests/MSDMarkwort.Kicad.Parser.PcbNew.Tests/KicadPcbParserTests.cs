namespace MSDMarkwort.Kicad.Parser.PcbNew.Tests
{
    public class KicadPcbParserTests
    {
        [SetUp]
        public void Setup()
        {
            /*
            var outFile = "";

            var cur = Directory.GetCurrentDirectory();

            var testProjects = Directory.GetFiles("../../../../TestProjects/", "*.kicad_pcb", SearchOption.AllDirectories);
            var testFiles = Directory.GetFiles("Files/", "*.kicad_pcb", SearchOption.AllDirectories);

            foreach (var file in testProjects.Concat(testFiles))
            {
                outFile += $"[TestCase(\"{file.Replace('\\', '/')}\")]\n";
            }
            */
        }

        [TestCase("../../../../TestProjects/complex_hierarchy/complex_hierarchy.kicad_pcb")]
        [TestCase("../../../../TestProjects/custom_pads_test/custom_pads_test.kicad_pcb")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp.kicad_pcb")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp_v2.kicad_pcb")]
        [TestCase("../../../../TestProjects/flat_hierarchy/flat_hierarchy.kicad_pcb")]
        [TestCase("../../../../TestProjects/interf_u/interf_u.kicad_pcb")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/kit-dev-coldfire-xilinx_5213.kicad_pcb")]
        [TestCase("../../../../TestProjects/microwave/microwave.kicad_pcb")]
        [TestCase("../../../../TestProjects/multichannel/multichannel_mixer-unrouted.kicad_pcb")]
        [TestCase("../../../../TestProjects/multichannel/multichannel_mixer.kicad_pcb")]
        [TestCase("../../../../TestProjects/pic_programmer/pic_programmer.kicad_pcb")]
        [TestCase("../../../../TestProjects/sonde xilinx/sonde xilinx.kicad_pcb")]
        [TestCase("../../../../TestProjects/stickhub/StickHub.kicad_pcb")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/test_pads_inside_pads.kicad_pcb")]
        [TestCase("../../../../TestProjects/test_xil_95108/carte_test.kicad_pcb")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-demo.kicad_pcb")]
        [TestCase("../../../../TestProjects/video/video.kicad_pcb")]
        [TestCase("Files/api_kitchen_sink.kicad_pcb")]
        [TestCase("Files/bad_triangulation_case.kicad_pcb")]
        [TestCase("Files/component_classes_drc.kicad_pcb")]
        [TestCase("Files/connection_width_rules.kicad_pcb")]
        [TestCase("Files/custom_fields.kicad_pcb")]
        [TestCase("Files/custom_pads.kicad_pcb")]
        [TestCase("Files/fakeboard.kicad_pcb", false)]
        [TestCase("Files/fill_bad.kicad_pcb")]
        [TestCase("Files/footprints_load_save.kicad_pcb")]
        [TestCase("Files/groups_load_save.kicad_pcb")]
        [TestCase("Files/groups_load_save_v20231212.kicad_pcb")]
        [TestCase("Files/group_and_image.kicad_pcb")]
        [TestCase("Files/group_and_image_formatted.kicad_pcb")]
        [TestCase("Files/intersectingzones.kicad_pcb")]
        [TestCase("Files/issue10906.kicad_pcb")]
        [TestCase("Files/issue10916.kicad_pcb")]
        [TestCase("Files/issue11814.kicad_pcb")]
        [TestCase("Files/issue12109.kicad_pcb")]
        [TestCase("Files/issue12609.kicad_pcb")]
        [TestCase("Files/issue12831.kicad_pcb")]
        [TestCase("Files/issue1358.kicad_pcb")]
        [TestCase("Files/issue14130.kicad_pcb")]
        [TestCase("Files/issue14294.kicad_pcb")]
        [TestCase("Files/issue14334.kicad_pcb")]
        [TestCase("Files/issue14412.kicad_pcb")]
        [TestCase("Files/issue14449.kicad_pcb")]
        [TestCase("Files/issue14549.kicad_pcb")]
        [TestCase("Files/issue14549_2.kicad_pcb")]
        [TestCase("Files/issue14559.kicad_pcb")]
        [TestCase("Files/issue15280.kicad_pcb")]
        [TestCase("Files/issue16182.kicad_pcb")]
        [TestCase("Files/issue16566.kicad_pcb")]
        [TestCase("Files/issue17559.kicad_pcb")]
        [TestCase("Files/issue17967.kicad_pcb")]
        [TestCase("Files/issue18.kicad_pcb")]
        [TestCase("Files/issue18142.kicad_pcb")]
        [TestCase("Files/issue2512.kicad_pcb")]
        [TestCase("Files/issue2528.kicad_pcb")]
        [TestCase("Files/issue2568.kicad_pcb")]
        [TestCase("Files/issue2904.kicad_pcb")]
        [TestCase("Files/issue3812.kicad_pcb")]
        [TestCase("Files/issue4774.kicad_pcb")]
        [TestCase("Files/issue5093.kicad_pcb")]
        [TestCase("Files/issue5102.kicad_pcb")]
        [TestCase("Files/issue5313.kicad_pcb")]
        [TestCase("Files/issue5320.kicad_pcb")]
        [TestCase("Files/issue5567.kicad_pcb")]
        [TestCase("Files/issue5750.kicad_pcb")]
        [TestCase("Files/issue5830.kicad_pcb")]
        [TestCase("Files/issue5854.kicad_pcb")]
        [TestCase("Files/issue5978.kicad_pcb")]
        [TestCase("Files/issue5990.kicad_pcb")]
        [TestCase("Files/issue6039.kicad_pcb")]
        [TestCase("Files/issue6260.kicad_pcb")]
        [TestCase("Files/issue6284.kicad_pcb")]
        [TestCase("Files/issue6443.kicad_pcb")]
        [TestCase("Files/issue6879.kicad_pcb")]
        [TestCase("Files/issue6945.kicad_pcb")]
        [TestCase("Files/issue7004.kicad_pcb")]
        [TestCase("Files/issue7086.kicad_pcb")]
        [TestCase("Files/issue7241.kicad_pcb")]
        [TestCase("Files/issue7267.kicad_pcb")]
        [TestCase("Files/issue7325.kicad_pcb")]
        [TestCase("Files/issue7567.kicad_pcb")]
        [TestCase("Files/issue7975.kicad_pcb")]
        [TestCase("Files/issue8003.kicad_pcb")]
        [TestCase("Files/issue832.kicad_pcb")]
        [TestCase("Files/issue8407.kicad_pcb")]
        [TestCase("Files/issue8883.kicad_pcb")]
        [TestCase("Files/issue8909.kicad_pcb")]
        [TestCase("Files/issue9081.kicad_pcb")]
        [TestCase("Files/issue9870.kicad_pcb")]
        [TestCase("Files/multinetclasses_drc.kicad_pcb")]
        [TestCase("Files/notched_zones.kicad_pcb")]
        [TestCase("Files/padstacks.kicad_pcb")]
        [TestCase("Files/padstacks_complex.kicad_pcb")]
        [TestCase("Files/padstacks_normal.kicad_pcb")]
        [TestCase("Files/reference_images_load_save.kicad_pcb")]
        [TestCase("Files/reverse_via.kicad_pcb")]
        [TestCase("Files/severities.kicad_pcb")]
        [TestCase("Files/skew_group_matched_drc.kicad_pcb")]
        [TestCase("Files/skew_within_diff_pairs_drc.kicad_pcb")]
        [TestCase("Files/sliver.kicad_pcb")]
        [TestCase("Files/solder_mask_bridge_test.kicad_pcb")]
        [TestCase("Files/teardrop_issue_JPC2.kicad_pcb")]
        [TestCase("Files/test_copper_graphics.kicad_pcb")]
        [TestCase("Files/tracks_arcs_vias.kicad_pcb")]
        [TestCase("Files/tuning_generators_load_save.kicad_pcb")]
        [TestCase("Files/tuning_generators_load_save_v20231212.kicad_pcb")]
        [TestCase("Files/unconnected-netnames.kicad_pcb")]
        [TestCase("Files/vme-wren.kicad_pcb")]
        [TestCase("Files/zone_filler.kicad_pcb")]
        [Parallelizable(ParallelScope.All)]
        public void ParseTest(string inputPcb, bool shouldParse = true, int warningsAllowed = 0)
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse(inputPcb);

            Assert.That(parserResult.Success, Is.EqualTo(shouldParse));
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(warningsAllowed));
        }
    }
}