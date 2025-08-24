using MSDMarkwort.Kicad.Parser.Model.Common;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.Model.Tests
{
    public class CommonModelToStringTests
    {
        [Test]
        public void Position_ToString_ReturnsFormattedString()
        {
            var position = new Position
            {
                X = 10.5,
                Y = 20.3
            };
            
            var result = position.ToString();
            
            Assert.That(result, Is.EqualTo("10.5/20.3"));
        }

        [Test]
        public void Position_ToStringWithZeroValues_ReturnsCorrectFormat()
        {
            var position = new Position
            {
                X = 0.0,
                Y = 0.0
            };
            
            var result = position.ToString();
            
            Assert.That(result, Is.EqualTo("0/0"));
        }

        [Test]
        public void Position_ToStringWithNegativeValues_HandlesCorrectly()
        {
            var position = new Position
            {
                X = -15.75,
                Y = -8.25
            };
            
            var result = position.ToString();
            
            Assert.That(result, Is.EqualTo("-15.75/-8.25"));
        }

        [Test]
        public void Position_ToStringWithLargeValues_HandlesCorrectly()
        {
            var position = new Position
            {
                X = 999999.999999,
                Y = -999999.999999
            };
            
            var result = position.ToString();
            
            Assert.That(result, Is.EqualTo("999999.999999/-999999.999999"));
        }

        [Test]
        public void Size_ToString_ReturnsFormattedString()
        {
            var size = new Size
            {
                Width = 100.0,
                Height = 50.5
            };
            
            var result = size.ToString();
            
            Assert.That(result, Is.EqualTo("100/50.5"));
        }

        [Test]
        public void Size_ToStringWithZeroValues_ReturnsCorrectFormat()
        {
            var size = new Size
            {
                Width = 0.0,
                Height = 0.0
            };
            
            var result = size.ToString();
            
            Assert.That(result, Is.EqualTo("0/0"));
        }

        [Test]
        public void Size_ToStringWithEqualDimensions_ReturnsSquareFormat()
        {
            var size = new Size
            {
                Width = 25.5,
                Height = 25.5
            };
            
            var result = size.ToString();
            
            Assert.That(result, Is.EqualTo("25.5/25.5"));
        }

        [Test]
        public void Size_ToStringWithVerySmallValues_HandlesCorrectly()
        {
            var size = new Size
            {
                Width = 0.001,
                Height = 0.002
            };
            
            var result = size.ToString();
            
            Assert.That(result, Is.EqualTo("0.001/0.002"));
        }

        [Test]
        public void Effects_ToString_UsesBaseImplementation()
        {
            var effects = new Effects();
            
            var result = effects.ToString();
            
            // Should use base Object.ToString() since no override is provided
            Assert.That(result, Is.EqualTo("MSDMarkwort.Kicad.Parser.Model.Common.Effects"));
        }

        [Test]
        public void Font_ToString_UsesBaseImplementation()
        {
            var font = new Font();
            
            var result = font.ToString();
            
            // Should use base Object.ToString() since no override is provided
            Assert.That(result, Is.EqualTo("MSDMarkwort.Kicad.Parser.Model.Common.Font"));
        }

        [Test]
        public void Color_ToString_UsesBaseImplementation()
        {
            var color = new Color();
            
            var result = color.ToString();
            
            // Should use base Object.ToString() since no override is provided
            Assert.That(result, Is.EqualTo("MSDMarkwort.Kicad.Parser.Model.Common.Color"));
        }

        [Test]
        public void PositionXYZ_ToString_ReturnsFormattedString()
        {
            var positionXYZ = new PositionXYZ
            {
                X = 10.5,
                Y = 20.3,
                Z = 5.7
            };
            
            var result = positionXYZ.ToString();
            
            Assert.That(result, Is.EqualTo("10.5/20.3/5.7"));
        }

        [Test]
        public void PositionXYZ_ToStringWithNegativeValues_HandlesCorrectly()
        {
            var positionXYZ = new PositionXYZ
            {
                X = -15.75,
                Y = -8.25,
                Z = -2.1
            };
            
            var result = positionXYZ.ToString();
            
            Assert.That(result, Is.EqualTo("-15.75/-8.25/-2.1"));
        }

        [Test]
        public void PositionAt_ToString_ReturnsFormattedString()
        {
            var positionAt = new PositionAt
            {
                X = 10.5,
                Y = 20.3,
                Angle = 45.0
            };
            
            var result = positionAt.ToString();
            
            Assert.That(result, Is.EqualTo("10.5/20.3 (45°)"));
        }

        [Test]
        public void PositionAt_ToStringWithZeroAngle_HandlesCorrectly()
        {
            var positionAt = new PositionAt
            {
                X = 0.0,
                Y = 0.0,
                Angle = 0.0
            };
            
            var result = positionAt.ToString();
            
            Assert.That(result, Is.EqualTo("0/0 (0°)"));
        }
    }
}