namespace MSDMarkwort.Kicad.Parser.EESchema.Tests
{
    public class KicadSymLibTableParserTests
    {
        [SetUp]
        public void Setup()
        {
            /*
            var outFile = "";

            var cur = Directory.GetCurrentDirectory();

            var testProjects = Directory.GetFiles("../../../../TestProjects/", "sym-lib-table", SearchOption.AllDirectories);

            foreach (var file in testProjects.Concat(testProjects))
            {
                outFile += $"[TestCase(\"{file.Replace('\\', '/')}\")]\n";
            }
            */
        }

        [TestCase("../../../../TestProjects/complex_hierarchy/sym-lib-table")]
        [TestCase("../../../../TestProjects/custom_pads_test/sym-lib-table")]
        [TestCase("../../../../TestProjects/ecc83/sym-lib-table")]
        [TestCase("../../../../TestProjects/flat_hierarchy/sym-lib-table")]
        [TestCase("../../../../TestProjects/interf_u/sym-lib-table")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/sym-lib-table")]
        [TestCase("../../../../TestProjects/pic_programmer/sym-lib-table")]
        [TestCase("../../../../TestProjects/sonde xilinx/sym-lib-table")]
        [TestCase("../../../../TestProjects/stickhub/sym-lib-table")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/sym-lib-table")]
        [TestCase("../../../../TestProjects/test_xil_95108/sym-lib-table")]
        [TestCase("../../../../TestProjects/tiny_tapeout/sym-lib-table")]
        [TestCase("../../../../TestProjects/video/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/class-d/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/gain_control/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/laser_driver/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/pspice/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/rectifier/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/sallen_key/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/v_i_sources/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/boost/sym-lib-table")]
        [TestCase("../../../../TestProjects/complex_hierarchy/sym-lib-table")]
        [TestCase("../../../../TestProjects/custom_pads_test/sym-lib-table")]
        [TestCase("../../../../TestProjects/ecc83/sym-lib-table")]
        [TestCase("../../../../TestProjects/flat_hierarchy/sym-lib-table")]
        [TestCase("../../../../TestProjects/interf_u/sym-lib-table")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/sym-lib-table")]
        [TestCase("../../../../TestProjects/pic_programmer/sym-lib-table")]
        [TestCase("../../../../TestProjects/sonde xilinx/sym-lib-table")]
        [TestCase("../../../../TestProjects/stickhub/sym-lib-table")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/sym-lib-table")]
        [TestCase("../../../../TestProjects/test_xil_95108/sym-lib-table")]
        [TestCase("../../../../TestProjects/tiny_tapeout/sym-lib-table")]
        [TestCase("../../../../TestProjects/video/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/class-d/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/gain_control/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/laser_driver/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/pspice/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/rectifier/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/sallen_key/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/v_i_sources/sym-lib-table")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/boost/sym-lib-table")]
        public void ParseTest(string inputSymLibTable, bool shouldParse = true, int warningsAllowed = 0)
        {
            var parser = new SymLibTableParser();
            var parserResult = parser.Parse(inputSymLibTable);

            Assert.That(parserResult.Success, Is.EqualTo(shouldParse));
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(warningsAllowed));
        }
    }
}
