using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartProperty;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.EESchema.Tests
{
    public class EESchemaModelToStringTests
    {
        [Test]
        public void Symbol_ToString_ReturnsName()
        {
            var symbol = new Symbol
            {
                Name = "TestSymbol"
            };
            
            var result = symbol.ToString();
            
            Assert.That(result, Is.EqualTo("TestSymbol"));
        }

        [Test]
        public void Symbol_ToStringWithNullName_ReturnsEmpty()
        {
            var symbol = new Symbol
            {
                Name = null
            };
            
            var result = symbol.ToString();
            
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void Symbol_ToStringWithEmptyName_ReturnsEmpty()
        {
            var symbol = new Symbol
            {
                Name = ""
            };
            
            var result = symbol.ToString();
            
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void Symbol_ToStringWithSpecialCharacters_HandlesCorrectly()
        {
            var symbol = new Symbol
            {
                Name = "Symbol_with-special.chars:123"
            };
            
            var result = symbol.ToString();
            
            Assert.That(result, Is.EqualTo("Symbol_with-special.chars:123"));
        }

        [Test]
        public void Property_ToString_ReturnsFormattedString()
        {
            var property = new Property
            {
                Name = "Reference",
                Value = "U1"
            };
            
            var result = property.ToString();
            
            Assert.That(result, Is.EqualTo("Reference: U1"));
        }

        [Test]
        public void Property_ToStringWithNullName_HandlesGracefully()
        {
            var property = new Property
            {
                Name = null,
                Value = "TestValue"
            };
            
            var result = property.ToString();
            
            Assert.That(result, Is.EqualTo(": TestValue"));
        }

        [Test]
        public void Property_ToStringWithNullValue_HandlesGracefully()
        {
            var property = new Property
            {
                Name = "TestName",
                Value = null
            };
            
            var result = property.ToString();
            
            Assert.That(result, Is.EqualTo("TestName: "));
        }

        [Test]
        public void Property_ToStringWithEmptyStrings_HandlesGracefully()
        {
            var property = new Property
            {
                Name = "",
                Value = ""
            };
            
            var result = property.ToString();
            
            Assert.That(result, Is.EqualTo(": "));
        }

        [Test]
        public void Property_ToStringWithLongValue_ReturnsFullValue()
        {
            var property = new Property
            {
                Name = "Description",
                Value = "This is a very long description with many characters that should be preserved in the ToString output"
            };
            
            var result = property.ToString();
            
            Assert.That(result, Is.EqualTo("Description: This is a very long description with many characters that should be preserved in the ToString output"));
        }

        [Test]
        public void Property_ToStringWithSpecialCharacters_HandlesCorrectly()
        {
            var property = new Property
            {
                Name = "Footprint",
                Value = "Package_DIP:DIP-8_W7.62mm"
            };
            
            var result = property.ToString();
            
            Assert.That(result, Is.EqualTo("Footprint: Package_DIP:DIP-8_W7.62mm"));
        }
    }
}