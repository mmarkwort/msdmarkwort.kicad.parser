using MSDMarkwort.Kicad.Parser.Base.Parser.Result;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CarteTestTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\carte_test.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void ComplexHierarchyTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\complex_hierarchy.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void CustomPadsTestTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\custom_pads_test.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void Ecc83ppTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\ecc83-pp.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void Ecc83ppV2Test()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\ecc83-pp_v2.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void FlatHierarchyTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\flat_hierarchy.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void InterfUTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\interf_u.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void KitDevColdfireXilinx5213Test()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\kit-dev-coldfire-xilinx_5213.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void MicrowaveTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\microwave.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void MultiChannelMixerTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\multichannel_mixer.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void MultiChannelMixerUnroutedTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\multichannel_mixer-unrouted.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void PicProgrammerTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\pic_programmer.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void SondeXilinxTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\sonde xilinx.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void StickHubTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\StickHub.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void TestPadsInsidePadsTest_WrongVersion()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\test_pads_inside_pads.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.IsNotNull(parserResult.Warnings.First(w => w.Warning == ParserWarnings.MaybeUnsupportedFileVersion));
        }

        [Test]
        public void TinyTapeOutDemoTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\tinytapeout-demo.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }

        [Test]
        public void VideoTest()
        {
            var parser = new PcbNewParser();
            var parserResult = parser.Parse("Files\\video.kicad_pcb");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }
    }
}