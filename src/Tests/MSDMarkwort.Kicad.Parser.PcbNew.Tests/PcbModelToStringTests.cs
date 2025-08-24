using System;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartProperty;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartLayers;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Tests
{
    public class PcbModelToStringTests
    {
        [Test]
        public void Net_ToString_ReturnsFormattedString()
        {
            var net = new Net
            {
                Number = 1,
                Name = "VCC"
            };
            
            var result = net.ToString();
            
            Assert.That(result, Is.EqualTo("1: VCC"));
        }

        [Test]
        public void Net_ToStringWithZeroNumber_ReturnsCorrectFormat()
        {
            var net = new Net
            {
                Number = 0,
                Name = "GND"
            };
            
            var result = net.ToString();
            
            Assert.That(result, Is.EqualTo("0: GND"));
        }

        [Test]
        public void Net_ToStringWithNullName_HandlesGracefully()
        {
            var net = new Net
            {
                Number = 5,
                Name = null
            };
            
            var result = net.ToString();
            
            Assert.That(result, Is.EqualTo("5: "));
        }

        [Test]
        public void Net_ToStringWithEmptyName_HandlesGracefully()
        {
            var net = new Net
            {
                Number = 10,
                Name = ""
            };
            
            var result = net.ToString();
            
            Assert.That(result, Is.EqualTo("10: "));
        }

        [Test]
        public void Net_ToStringWithLongName_ReturnsFullName()
        {
            var net = new Net
            {
                Number = 99,
                Name = "Very_Long_Net_Name_With_Many_Characters_And_Underscores"
            };
            
            var result = net.ToString();
            
            Assert.That(result, Is.EqualTo("99: Very_Long_Net_Name_With_Many_Characters_And_Underscores"));
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
        public void Property_ToStringWithSpecialCharacters_HandlesCorrectly()
        {
            var property = new Property
            {
                Name = "Description",
                Value = "Test & Component (R1) \"quoted\""
            };
            
            var result = property.ToString();
            
            Assert.That(result, Is.EqualTo("Description: Test & Component (R1) \"quoted\""));
        }

        [Test]
        public void Footprint_ToStringWithDescription_ReturnsDescription()
        {
            var footprint = new Footprint
            {
                Name = "TestFootprint",
                Description = "Test Description"
            };
            
            var result = footprint.ToString();
            
            Assert.That(result, Is.EqualTo("Test Description"));
        }

        [Test]
        public void Footprint_ToStringWithNullDescription_ReturnsNull()
        {
            var footprint = new Footprint
            {
                Name = "TestFootprint",
                Description = null
            };
            
            var result = footprint.ToString();
            
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Footprint_ToStringWithEmptyDescription_ReturnsEmpty()
        {
            var footprint = new Footprint
            {
                Name = "TestFootprint",
                Description = ""
            };
            
            var result = footprint.ToString();
            
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void BoardLayer_ToString_ReturnsFormattedString()
        {
            var boardLayer = new BoardLayer
            {
                Number = 1,
                ShortName = "F.Cu",
                LayerType = "signal",
                Name = "Front Copper"
            };
            
            var result = boardLayer.ToString();
            
            Assert.That(result, Is.EqualTo("(1) F.Cu -> signal (Front Copper)"));
        }

        [Test]
        public void BoardLayer_ToStringWithNullValues_HandlesGracefully()
        {
            var boardLayer = new BoardLayer
            {
                Number = 2,
                ShortName = "B.Cu",
                LayerType = null,
                Name = null
            };
            
            var result = boardLayer.ToString();
            
            Assert.That(result, Is.EqualTo("(2) B.Cu ->  ()"));
        }
    }
}