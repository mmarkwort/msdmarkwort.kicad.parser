namespace MSDMarkwort.Kicad.Parser.EESchema.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Files/a-multi.kicad_sch")]
        [TestCase("Files/ampli_ht.kicad_sch")]
        [TestCase("Files/buck_conv.kicad_sch")]
        [TestCase("Files/bus_pci.kicad_sch")]
        [TestCase("Files/carte_test.kicad_sch")]
        [TestCase("Files/channel_strip.kicad_sch")]
        [TestCase("Files/Class-D.kicad_sch")]
        [TestCase("Files/complex_hierarchy.kicad_sch")]
        [TestCase("Files/custom_pads_test.kicad_sch")]
        [TestCase("Files/ecc83-pp.kicad_sch")]
        [TestCase("Files/ecc83-pp_v2.kicad_sch")]
        [TestCase("Files/esvideo.kicad_sch")]
        [TestCase("Files/flat_hierarchy.kicad_sch")]
        [TestCase("Files/graphic.kicad_sch")]
        [TestCase("Files/hv_converter.kicad_sch")]
        [TestCase("Files/ibis.kicad_sch")]
        [TestCase("Files/interf_u.kicad_sch")]
        [TestCase("Files/in_out_conn.kicad_sch")]
        [TestCase("Files/kit-dev-coldfire-xilinx_5213.kicad_sch")]
        [TestCase("Files/laser_driver.kicad_sch")]
        [TestCase("Files/modul.kicad_sch")]
        [TestCase("Files/multichannel_mixer.kicad_sch")]
        [TestCase("Files/mult_vca810.kicad_sch")]
        [TestCase("Files/muxdata.kicad_sch")]
        [TestCase("Files/pal-ntsc.kicad_sch")]
        [TestCase("Files/pic_programmer.kicad_sch")]
        [TestCase("Files/pic_sockets.kicad_sch")]
        [TestCase("Files/power_supply.kicad_sch")]
        [TestCase("Files/pspice.kicad_sch")]
        [TestCase("Files/Q17ng.kicad_sch")]
        [TestCase("Files/rams.kicad_sch")]
        [TestCase("Files/rectifier.kicad_sch")]
        [TestCase("Files/royer1.kicad_sch")]
        [TestCase("Files/rp2040.kicad_sch")]
        [TestCase("Files/sallen_key.kicad_sch")]
        [TestCase("Files/smps-com.kicad_sch")]
        [TestCase("Files/sonde xilinx.kicad_sch")]
        [TestCase("Files/StickHub.kicad_sch")]
        [TestCase("Files/subsheet1.kicad_sch")]
        [TestCase("Files/subsheet2.kicad_sch")]
        [TestCase("Files/subsheets.kicad_sch")]
        [TestCase("Files/test_pads_inside_pads.kicad_sch")]
        [TestCase("Files/tinytapeout-demo.kicad_sch")]
        [TestCase("Files/up-down-c.kicad_sch")]
        [TestCase("Files/video.kicad_sch")]
        [TestCase("Files/v_i_sources.kicad_sch")]
        [TestCase("Files/xilinx.kicad_sch")]
        public void ParseTest(string inputPcb, bool shouldParse = true, int warningsAllowed = 0)
        {
            /*
            var outAttr = "";
            foreach (var file in Directory.GetFiles("Files/"))
            {
                outAttr += $"[TestCase(\"{file}\")]\n";
            }
            */

            var parser = new EESchemaParser();
            var parserResult = parser.Parse(inputPcb);

            Assert.That(parserResult.Success, Is.EqualTo(shouldParse));
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(warningsAllowed));
        }
    }
}