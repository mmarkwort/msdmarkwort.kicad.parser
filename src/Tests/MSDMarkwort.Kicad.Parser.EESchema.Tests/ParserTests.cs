namespace MSDMarkwort.Kicad.Parser.EESchema.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
        [TestCase("Files/ampli_ht.kicad_sch")]
        public void ParseTest(string inputPcb, bool shouldParse = true, int warningsAllowed = 0)
        {
            var parser = new EESchemaParser();
            var parserResult = parser.Parse(inputPcb);

            Assert.That(parserResult.Success, Is.EqualTo(shouldParse));
            Assert.That(parserResult.Warnings.Length, Is.EqualTo(warningsAllowed));
        }
        */
    }
}