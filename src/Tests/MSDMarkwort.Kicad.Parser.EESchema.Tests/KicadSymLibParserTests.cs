namespace MSDMarkwort.Kicad.Parser.EESchema.Tests
{
    public class KicadSymLibParserTests
    {
        [SetUp]
        public void Setup()
        {
            /*
            var outFile = "";

            var cur = Directory.GetCurrentDirectory();

            var testProjects = Directory.GetFiles("../../../../TestProjects/", "*.kicad_sym", SearchOption.AllDirectories);

            foreach (var file in testProjects.Concat(testProjects))
            {
                outFile += $"[TestCase(\"{file.Replace('\\', '/')}\")]\n";
            }
            */
        }

        [TestCase("../../../../TestProjects/complex_hierarchy/complex_hierarchy_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/custom_pads_test/custom_pads_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/ecc83/ecc83_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/interf_u/interf_u_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/interf_u/tux.kicad_sym")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/kit-coldfire_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/sonde xilinx/sonde_xilinx_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/stickhub/RobotProtos.kicad_sym")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/test_pads_inside_pads_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/test_xil_95108/carte_test_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/flat_hierarchy/libs/flat_hierarchy_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/pic_programmer/libs/pic_programmer_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/class-d/AudioDriver.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/gain_control/VCA810.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/laser_driver/laser_driver_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/pspice/schematic_libspice.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/rectifier/rectifier_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/sallen_key/sallen_key_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/up-down-counter/up-down.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/v_i_sources/v_i_sources.kicad_sym")]
        [TestCase("../../../../TestProjects/video/libs/video_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/boost/PWM.kicad_sym")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-kicad-libs/symbols/MCU_RaspberryPi_and_Boards.kicad_sym")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-kicad-libs/symbols/TinyTapeout.kicad_sym")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-kicad-libs/symbols/ttlib.kicad_sym")]
        [TestCase("../../../../TestProjects/complex_hierarchy/complex_hierarchy_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/custom_pads_test/custom_pads_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/ecc83/ecc83_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/interf_u/interf_u_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/interf_u/tux.kicad_sym")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/kit-coldfire_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/sonde xilinx/sonde_xilinx_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/stickhub/RobotProtos.kicad_sym")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/test_pads_inside_pads_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/test_xil_95108/carte_test_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/flat_hierarchy/libs/flat_hierarchy_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/pic_programmer/libs/pic_programmer_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/class-d/AudioDriver.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/gain_control/VCA810.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/laser_driver/laser_driver_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/pspice/schematic_libspice.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/rectifier/rectifier_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/sallen_key/sallen_key_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/up-down-counter/up-down.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/v_i_sources/v_i_sources.kicad_sym")]
        [TestCase("../../../../TestProjects/video/libs/video_schlib.kicad_sym")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/boost/PWM.kicad_sym")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-kicad-libs/symbols/MCU_RaspberryPi_and_Boards.kicad_sym")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-kicad-libs/symbols/TinyTapeout.kicad_sym")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-kicad-libs/symbols/ttlib.kicad_sym")]
        public void ParseTest(string inputSymLib, bool shouldParse = true, int warningsAllowed = 0)
        {
            var parser = new SymLibParser();
            var parserResult = parser.Parse(inputSymLib);

            Assert.That(parserResult.Success, Is.EqualTo(shouldParse));
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(warningsAllowed));
        }
    }
}
