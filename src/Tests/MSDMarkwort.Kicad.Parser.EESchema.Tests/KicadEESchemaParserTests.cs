namespace MSDMarkwort.Kicad.Parser.EESchema.Tests
{
    public class KicadEESchemaParserTests
    {
        [SetUp]
        public void Setup()
        {
            /*
            var outFile = "";

            var cur = Directory.GetCurrentDirectory();

            var testProjects = Directory.GetFiles("../../../../TestProjects/", "*.kicad_sch", SearchOption.AllDirectories);

            foreach (var file in testProjects.Concat(testProjects))
            {
                outFile += $"[TestCase(\"{file.Replace('\\', '/')}\")]\n";
            }
            */
        }

        [TestCase("../../../../TestProjects/complex_hierarchy/ampli_ht.kicad_sch")]
        [TestCase("../../../../TestProjects/complex_hierarchy/complex_hierarchy.kicad_sch")]
        [TestCase("../../../../TestProjects/custom_pads_test/custom_pads_test.kicad_sch")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp.kicad_sch")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp_v2.kicad_sch")]
        [TestCase("../../../../TestProjects/flat_hierarchy/flat_hierarchy.kicad_sch")]
        [TestCase("../../../../TestProjects/flat_hierarchy/pic_programmer.kicad_sch")]
        [TestCase("../../../../TestProjects/flat_hierarchy/pic_sockets.kicad_sch")]
        [TestCase("../../../../TestProjects/interf_u/interf_u.kicad_sch")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/in_out_conn.kicad_sch")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/kit-dev-coldfire-xilinx_5213.kicad_sch")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/xilinx.kicad_sch")]
        [TestCase("../../../../TestProjects/multichannel/channel_strip.kicad_sch")]
        [TestCase("../../../../TestProjects/multichannel/multichannel_mixer.kicad_sch")]
        [TestCase("../../../../TestProjects/pic_programmer/pic_programmer.kicad_sch")]
        [TestCase("../../../../TestProjects/pic_programmer/pic_sockets.kicad_sch")]
        [TestCase("../../../../TestProjects/sonde xilinx/sonde xilinx.kicad_sch")]
        [TestCase("../../../../TestProjects/stickhub/StickHub.kicad_sch")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/test_pads_inside_pads.kicad_sch")]
        [TestCase("../../../../TestProjects/test_xil_95108/carte_test.kicad_sch")]
        [TestCase("../../../../TestProjects/tiny_tapeout/rp2040.kicad_sch")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-demo.kicad_sch")]
        [TestCase("../../../../TestProjects/video/bus_pci.kicad_sch")]
        [TestCase("../../../../TestProjects/video/esvideo.kicad_sch")]
        [TestCase("../../../../TestProjects/video/graphic.kicad_sch")]
        [TestCase("../../../../TestProjects/video/modul.kicad_sch")]
        [TestCase("../../../../TestProjects/video/muxdata.kicad_sch")]
        [TestCase("../../../../TestProjects/video/pal-ntsc.kicad_sch")]
        [TestCase("../../../../TestProjects/video/rams.kicad_sch")]
        [TestCase("../../../../TestProjects/video/video.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/analog-multiplier/a-multi.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/class-d/Class-D.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/gain_control/mult_vca810.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/ibis/ibis.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/laser_driver/laser_driver.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/pspice/pspice.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/q17/Q17ng.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/rectifier/rectifier.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/sallen_key/sallen_key.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/subsheets/subsheet1.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/subsheets/subsheet2.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/subsheets/subsheets.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/up-down-counter/up-down-c.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/v_i_sources/v_i_sources.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/boost/smps-com.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/buck_conv/buck_conv.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/hv_converter/hv_converter.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/LM317_power_supply/power_supply.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/royer/royer1.kicad_sch")]
        [TestCase("../../../../TestProjects/complex_hierarchy/ampli_ht.kicad_sch")]
        [TestCase("../../../../TestProjects/complex_hierarchy/complex_hierarchy.kicad_sch")]
        [TestCase("../../../../TestProjects/custom_pads_test/custom_pads_test.kicad_sch")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp.kicad_sch")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp_v2.kicad_sch")]
        [TestCase("../../../../TestProjects/flat_hierarchy/flat_hierarchy.kicad_sch")]
        [TestCase("../../../../TestProjects/flat_hierarchy/pic_programmer.kicad_sch")]
        [TestCase("../../../../TestProjects/flat_hierarchy/pic_sockets.kicad_sch")]
        [TestCase("../../../../TestProjects/interf_u/interf_u.kicad_sch")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/in_out_conn.kicad_sch")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/kit-dev-coldfire-xilinx_5213.kicad_sch")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/xilinx.kicad_sch")]
        [TestCase("../../../../TestProjects/multichannel/channel_strip.kicad_sch")]
        [TestCase("../../../../TestProjects/multichannel/multichannel_mixer.kicad_sch")]
        [TestCase("../../../../TestProjects/pic_programmer/pic_programmer.kicad_sch")]
        [TestCase("../../../../TestProjects/pic_programmer/pic_sockets.kicad_sch")]
        [TestCase("../../../../TestProjects/sonde xilinx/sonde xilinx.kicad_sch")]
        [TestCase("../../../../TestProjects/stickhub/StickHub.kicad_sch")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/test_pads_inside_pads.kicad_sch")]
        [TestCase("../../../../TestProjects/test_xil_95108/carte_test.kicad_sch")]
        [TestCase("../../../../TestProjects/tiny_tapeout/rp2040.kicad_sch")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-demo.kicad_sch")]
        [TestCase("../../../../TestProjects/video/bus_pci.kicad_sch")]
        [TestCase("../../../../TestProjects/video/esvideo.kicad_sch")]
        [TestCase("../../../../TestProjects/video/graphic.kicad_sch")]
        [TestCase("../../../../TestProjects/video/modul.kicad_sch")]
        [TestCase("../../../../TestProjects/video/muxdata.kicad_sch")]
        [TestCase("../../../../TestProjects/video/pal-ntsc.kicad_sch")]
        [TestCase("../../../../TestProjects/video/rams.kicad_sch")]
        [TestCase("../../../../TestProjects/video/video.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/analog-multiplier/a-multi.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/class-d/Class-D.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/gain_control/mult_vca810.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/ibis/ibis.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/laser_driver/laser_driver.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/pspice/pspice.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/q17/Q17ng.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/rectifier/rectifier.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/sallen_key/sallen_key.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/subsheets/subsheet1.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/subsheets/subsheet2.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/subsheets/subsheets.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/up-down-counter/up-down-c.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/v_i_sources/v_i_sources.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/boost/smps-com.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/buck_conv/buck_conv.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/hv_converter/hv_converter.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/LM317_power_supply/power_supply.kicad_sch")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/royer/royer1.kicad_sch")]
        public void ParseTest(string inputSchema, bool shouldParse = true, int warningsAllowed = 0)
        {
            var parser = new EESchemaParser();
            var parserResult = parser.Parse(inputSchema);

            Assert.That(parserResult.Success, Is.EqualTo(shouldParse));
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(warningsAllowed));
        }
    }
}
