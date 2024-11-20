namespace MSDMarkwort.Kicad.Parser.EESchema.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AmpliHtTest()
        {
            var parser = new EESchemaParser();
            var parserResult = parser.Parse("Files/ampli_ht.kicad_sch");

            Assert.IsTrue(parserResult.Success);
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(0));
        }
    }
}