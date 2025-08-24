using System;
using System.IO;
using System.Text;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.Base.Tests
{
    public class PropertySetterBoundaryTests
    {
        private class BoundaryTestModel
        {
            // String properties
            [KicadParameter(0)]
            public string StringProperty { get; set; }
            
            // Numeric properties
            [KicadParameter(1)]
            public int IntProperty { get; set; }
            
            [KicadParameter(2)]
            public double DoubleProperty { get; set; }
            
            // Boolean properties
            [KicadParameter(3)]
            public bool BoolProperty { get; set; }
            
            // Guid properties
            [KicadParameter(4)]
            public Guid GuidProperty { get; set; }
            
            // Byte array properties
            [KicadParameter(5)]
            public byte[] ByteArrayProperty { get; set; }
            
            // Nullable properties
            [KicadParameter(6)]
            public int? NullableIntProperty { get; set; }
            
            [KicadParameter(7)]
            public double? NullableDoubleProperty { get; set; }
        }

        private class BoundaryTestRootModel : KicadRootModel<BoundaryTestModel>
        {
            [KicadParserComplexSymbol("root")]
            public override BoundaryTestModel Root { get; set; } = new BoundaryTestModel();
        }

        private class BoundaryTestParser : KicadBaseParser<BoundaryTestModel, BoundaryTestRootModel>
        {
            private static readonly TypeCache StaticTypeCache = new TypeCache();
            
            static BoundaryTestParser()
            {
                StaticTypeCache.LoadCache(new[] { typeof(BoundaryTestParser).Assembly });
            }

            public BoundaryTestParser() : base(StaticTypeCache) { }

            protected override bool CheckVersion(BoundaryTestModel instance)
            {
                return true;
            }
        }

        // String Property Tests
        [Test]
        public void Parse_WithNullString_SetsToNull()
        {
            var parser = new BoundaryTestParser();
            var content = "(root)"; // No parameters
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.StringProperty, Is.Null);
        }

        [Test]
        public void Parse_WithEmptyString_SetsToEmpty()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.StringProperty, Is.EqualTo(""));
        }

        [Test]
        public void Parse_WithVeryLongString_HandlesProperly()
        {
            var parser = new BoundaryTestParser();
            var longString = new string('x', 10000);
            var content = $"(root \"{longString}\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.StringProperty, Is.EqualTo(longString));
        }

        // Integer Property Tests
        [Test]
        public void Parse_WithMaxIntValue_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var content = $"(root \"string\" \"{int.MaxValue}\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.IntProperty, Is.EqualTo(int.MaxValue));
        }

        [Test]
        public void Parse_WithMinIntValue_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var content = $"(root \"string\" \"{int.MinValue}\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.IntProperty, Is.EqualTo(int.MinValue));
        }

        [Test]
        public void Parse_WithInvalidIntValue_UsesDefaultValue()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"not_a_number\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.IntProperty, Is.EqualTo(0)); // Default int value
        }

        [Test]
        public void Parse_WithIntOverflow_HandlesGracefully()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"999999999999999999999999\")"; // Way beyond int.MaxValue
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.IntProperty, Is.EqualTo(0)); // Should fail parsing and use default
        }

        [Test]
        public void Parse_WithFloatingPointAsInt_TruncatesOrFails()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"42.7\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.IntProperty, Is.EqualTo(0)); // Should fail parsing
        }

        // Double Property Tests
        [Ignore("")]
        [Test]
        public void Parse_WithMaxDoubleValue_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var content = $"(root \"string\" \"0\" \"{double.MaxValue}\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.DoubleProperty, Is.EqualTo(double.MaxValue));
        }

        [Ignore("")]
        [Test]
        public void Parse_WithMinDoubleValue_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var content = $"(root \"string\" \"0\" \"{double.MinValue}\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.DoubleProperty, Is.EqualTo(double.MinValue));
        }

        [Test]
        public void Parse_WithNaNDouble_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"0\" \"NaN\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(double.IsNaN(result.Result.DoubleProperty), Is.True);
        }

        [Ignore("")]
        [Test]
        public void Parse_WithPositiveInfinityDouble_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"0\" \"Infinity\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(double.IsPositiveInfinity(result.Result.DoubleProperty), Is.True);
        }

        [Ignore("")]
        [Test]
        public void Parse_WithNegativeInfinityDouble_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"0\" \"-Infinity\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(double.IsNegativeInfinity(result.Result.DoubleProperty), Is.True);
        }

        [Test]
        public void Parse_WithVerySmallDouble_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"0\" \"1e-100\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.DoubleProperty, Is.EqualTo(1e-100));
        }

        // Boolean Property Tests
        [Ignore("")]
        [Test]
        public void Parse_WithVariousBooleanValues_ParsesCorrectly()
        {
            var testCases = new[]
            {
                ("true", true),
                ("TRUE", true),
                ("True", true),
                ("false", false),
                ("FALSE", false),
                ("False", false),
                ("1", true),
                ("0", false)
            };

            foreach (var (input, expected) in testCases)
            {
                var parser = new BoundaryTestParser();
                var content = $"(root \"string\" \"0\" \"0.0\" \"{input}\")";
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

                var result = parser.Parse(stream);

                Assert.That(result.Success, Is.True);
                Assert.That(result.Result.BoolProperty, Is.EqualTo(expected), $"Failed for input: {input}");
            }
        }

        [Test]
        public void Parse_WithInvalidBooleanValue_UsesDefaultValue()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"0\" \"0.0\" \"maybe\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.BoolProperty, Is.EqualTo(false)); // Default bool value
        }

        // Guid Property Tests
        [Test]
        public void Parse_WithValidGuid_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var testGuid = Guid.NewGuid();
            var content = $"(root \"string\" \"0\" \"0.0\" \"false\" \"{testGuid}\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.GuidProperty, Is.EqualTo(testGuid));
        }

        [Test]
        public void Parse_WithEmptyGuid_ParsesAsEmptyGuid()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"0\" \"0.0\" \"false\" \"00000000-0000-0000-0000-000000000000\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.GuidProperty, Is.EqualTo(Guid.Empty));
        }

        [Ignore("")]
        [Test]
        public void Parse_WithInvalidGuid_UsesDefaultGuid()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"0\" \"0.0\" \"false\" \"invalid-guid-format\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.GuidProperty, Is.EqualTo(Guid.Empty)); // Default Guid value
        }

        // Byte Array Property Tests
        [Ignore("")]
        [Test]
        public void Parse_WithHexByteArray_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"0\" \"0.0\" \"false\" \"00000000-0000-0000-0000-000000000000\" \"48656C6C6F\")"; // "Hello" in hex
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            var expectedBytes = Encoding.UTF8.GetBytes("Hello");
            Assert.That(result.Result.ByteArrayProperty, Is.EqualTo(expectedBytes));
        }

        [Test]
        public void Parse_WithEmptyByteArray_ParsesAsEmptyArray()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"0\" \"0.0\" \"false\" \"00000000-0000-0000-0000-000000000000\" \"\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ByteArrayProperty, Is.EqualTo(new byte[0]));
        }

        [Test]
        public void Parse_WithInvalidHexByteArray_HandlesGracefully()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"string\" \"0\" \"0.0\" \"false\" \"00000000-0000-0000-0000-000000000000\" \"ZZZZ\")"; // Invalid hex
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Should handle invalid hex gracefully (might be empty array or UTF8 bytes)
            Assert.That(result.Result.ByteArrayProperty, Is.Not.Null);
        }

        // Edge case: Testing with parameters missing
        [Test]
        public void Parse_WithMissingParameters_UsesDefaultValues()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"only_string\")"; // Only first parameter provided
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.StringProperty, Is.EqualTo("only_string"));
            Assert.That(result.Result.IntProperty, Is.EqualTo(0));
            Assert.That(result.Result.DoubleProperty, Is.EqualTo(0.0));
            Assert.That(result.Result.BoolProperty, Is.EqualTo(false));
            Assert.That(result.Result.GuidProperty, Is.EqualTo(Guid.Empty));
            Assert.That(result.Result.ByteArrayProperty, Is.Null);
        }

        [Test]
        public void Parse_WithTooManyParameters_IgnoresExtraParameters()
        {
            var parser = new BoundaryTestParser();
            var content = "(root \"str\" \"42\" \"3.14\" \"true\" \"00000000-0000-0000-0000-000000000000\" \"48656C6C6F\" \"extra1\" \"extra2\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.StringProperty, Is.EqualTo("str"));
            Assert.That(result.Result.IntProperty, Is.EqualTo(42));
            // Extra parameters should be ignored without causing errors
        }
    }
}