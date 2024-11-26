using MSDMarkwort.Kicad.Parser.EESchema;
using System.IO;
using System.Text;

namespace MSDMarkwort.Kicad.Parser.Project.Tests
{
    public class KicadProjectParserTests
    {
        [SetUp]
        public void Setup()
        {
            /*
            var outFile = "";

            var cur = Directory.GetCurrentDirectory();

            var testProjects = Directory.GetFiles("../../../../TestProjects/", "*.kicad_pro", SearchOption.AllDirectories);

            foreach (var file in testProjects.Concat(testProjects))
            {
                outFile += $"[TestCase(\"{file.Replace('\\', '/')}\")]\n";
            }
            */
        }

        [TestCase("../../../../TestProjects/complex_hierarchy/complex_hierarchy.kicad_pro")]
        [TestCase("../../../../TestProjects/custom_pads_test/custom_pads_test.kicad_pro")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp.kicad_pro")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp_v2.kicad_pro")]
        [TestCase("../../../../TestProjects/flat_hierarchy/flat_hierarchy.kicad_pro")]
        [TestCase("../../../../TestProjects/interf_u/interf_u.kicad_pro")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/kit-dev-coldfire-xilinx_5213.kicad_pro")]
        [TestCase("../../../../TestProjects/microwave/microwave.kicad_pro")]
        [TestCase("../../../../TestProjects/multichannel/multichannel_mixer.kicad_pro")]
        [TestCase("../../../../TestProjects/pic_programmer/pic_programmer.kicad_pro")]
        [TestCase("../../../../TestProjects/sonde xilinx/sonde xilinx.kicad_pro")]
        [TestCase("../../../../TestProjects/stickhub/StickHub.kicad_pro")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/test_pads_inside_pads.kicad_pro")]
        [TestCase("../../../../TestProjects/test_xil_95108/carte_test.kicad_pro")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-demo.kicad_pro")]
        [TestCase("../../../../TestProjects/video/video.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/analog-multiplier/a-multi.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/class-d/Class-D.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/gain_control/mult_vca810.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/generic_models/generic_opamp_bip.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/ibis/ibis.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/laser_driver/laser_driver.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/pspice/pspice.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/q17/Q17ng.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/rectifier/rectifier.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/sallen_key/sallen_key.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/up-down-counter/up-down-c.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/v_i_sources/v_i_sources.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/boost/smps-com.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/buck_conv/buck_conv.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/hv_converter/hv_converter.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/LM317_power_supply/power_supply.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/royer/royer1.kicad_pro")]
        [TestCase("../../../../TestProjects/complex_hierarchy/complex_hierarchy.kicad_pro")]
        [TestCase("../../../../TestProjects/custom_pads_test/custom_pads_test.kicad_pro")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp.kicad_pro")]
        [TestCase("../../../../TestProjects/ecc83/ecc83-pp_v2.kicad_pro")]
        [TestCase("../../../../TestProjects/flat_hierarchy/flat_hierarchy.kicad_pro")]
        [TestCase("../../../../TestProjects/interf_u/interf_u.kicad_pro")]
        [TestCase("../../../../TestProjects/kit-dev-coldfire-xilinx_5213/kit-dev-coldfire-xilinx_5213.kicad_pro")]
        [TestCase("../../../../TestProjects/microwave/microwave.kicad_pro")]
        [TestCase("../../../../TestProjects/multichannel/multichannel_mixer.kicad_pro")]
        [TestCase("../../../../TestProjects/pic_programmer/pic_programmer.kicad_pro")]
        [TestCase("../../../../TestProjects/sonde xilinx/sonde xilinx.kicad_pro")]
        [TestCase("../../../../TestProjects/stickhub/StickHub.kicad_pro")]
        [TestCase("../../../../TestProjects/test_pads_inside_pads/test_pads_inside_pads.kicad_pro")]
        [TestCase("../../../../TestProjects/test_xil_95108/carte_test.kicad_pro")]
        [TestCase("../../../../TestProjects/tiny_tapeout/tinytapeout-demo.kicad_pro")]
        [TestCase("../../../../TestProjects/video/video.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/analog-multiplier/a-multi.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/class-d/Class-D.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/gain_control/mult_vca810.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/generic_models/generic_opamp_bip.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/ibis/ibis.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/laser_driver/laser_driver.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/pspice/pspice.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/q17/Q17ng.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/rectifier/rectifier.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/sallen_key/sallen_key.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/up-down-counter/up-down-c.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/v_i_sources/v_i_sources.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/boost/smps-com.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/buck_conv/buck_conv.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/hv_converter/hv_converter.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/LM317_power_supply/power_supply.kicad_pro")]
        [TestCase("../../../../TestProjects/simulation/power_supplies/royer/royer1.kicad_pro")]
        public async Task ParseTest(string inputProject)
        {
            var memoryStream = new MemoryStream();
            await using var inputProjectStream = File.OpenRead(inputProject);

            var parser = new KicadProjectParser();
            var writer = new KicadProjectWriter();

            var parserResult = await parser.ParseAsync(inputProjectStream);
            inputProjectStream.Seek(0, SeekOrigin.Begin);

            var inputProjectContent = "";
            using (var reader = new StreamReader(inputProjectStream))
            {
                inputProjectContent = await reader.ReadToEndAsync();
            }

            Assert.That(parserResult.Success, Is.EqualTo(true));

            await writer.WriteAsync(parserResult.Result, memoryStream);
            var outputProjectContent = Encoding.UTF8.GetString(memoryStream.ToArray());

            Assert.That(outputProjectContent, Is.EqualTo(inputProjectContent));
        }
    }
}
