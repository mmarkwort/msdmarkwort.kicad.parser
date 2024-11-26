namespace MSDMarkwort.Kicad.Parser.PcbNew.Tests
{
    public class KicadFootprintLibTableParserTests
    {
        [SetUp]
        public void Setup()
        {
            /*
            var outFile = "";

            var cur = Directory.GetCurrentDirectory();

            var testProjects = Directory.GetFiles("../../../../TestProjects/", "fp-lib-table", SearchOption.AllDirectories);

            foreach (var file in testProjects.Concat(testProjects))
            {
                outFile += $"[TestCase(\"{file.Replace('\\', '/')}\")]\n";
            }
            */
        }

        [TestCase("../../../../TestProjects/complex_hierarchy/fp-lib-table")]
        [TestCase("../../../../TestProjects/ecc83/fp-lib-table")]
        [TestCase("../../../../TestProjects/flat_hierarchy/fp-lib-table")]
        [TestCase("../../../../TestProjects/interf_u/fp-lib-table")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/fp-lib-table")]
        [TestCase("../../../../TestProjects/pic_programmer/fp-lib-table")]
        [TestCase("../../../../TestProjects/sonde xilinx/fp-lib-table")]
        [TestCase("../../../../TestProjects/stickhub/fp-lib-table")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/fp-lib-table")]
        [TestCase("../../../../TestProjects/test_xil_95108/fp-lib-table")]
        [TestCase("../../../../TestProjects/tiny_tapeout/fp-lib-table")]
        [TestCase("../../../../TestProjects/video/fp-lib-table")]
        [TestCase("../../../../TestProjects/complex_hierarchy/fp-lib-table")]
        [TestCase("../../../../TestProjects/ecc83/fp-lib-table")]
        [TestCase("../../../../TestProjects/flat_hierarchy/fp-lib-table")]
        [TestCase("../../../../TestProjects/interf_u/fp-lib-table")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/fp-lib-table")]
        [TestCase("../../../../TestProjects/pic_programmer/fp-lib-table")]
        [TestCase("../../../../TestProjects/sonde xilinx/fp-lib-table")]
        [TestCase("../../../../TestProjects/stickhub/fp-lib-table")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/fp-lib-table")]
        [TestCase("../../../../TestProjects/test_xil_95108/fp-lib-table")]
        [TestCase("../../../../TestProjects/tiny_tapeout/fp-lib-table")]
        [TestCase("../../../../TestProjects/video/fp-lib-table")]
        public void ParseTest(string inputFootprintLib, bool shouldParse = true, int warningsAllowed = 0)
        {
            var parser = new FootprintLibTableParser();
            var parserResult = parser.Parse(inputFootprintLib);

            Assert.That(parserResult.Success, Is.EqualTo(shouldParse));
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(warningsAllowed));
        }
    }
}
