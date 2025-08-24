using System;
using System.IO;
using System.Text;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.Base.Tests
{
    public class EnumPropertySetterEdgeCaseTests
    {
        private enum TestEnum
        {
            DefaultValue,
            FirstValue,
            SecondValue,
            DashDotValue,
            Snake_case_value,
            UPPERCASE_VALUE,
            UppercaseValue, // Normalized from "uppercase_value"
            mixedCaseValue,
            WithNumbers123,
            FCu, // Simulates layer name after normalization
            BSilkS // Simulates layer name after normalization
        }

        private enum SingleValueEnum
        {
            OnlyValue
        }

        private enum EmptyEnum
        {
            // Empty enum for edge case testing
        }

        private class EnumTestModel
        {
            [KicadParserSymbol("test_enum")]
            public TestEnum TestEnumProperty { get; set; }
            
            [KicadParserSymbol("single_enum")]
            public SingleValueEnum SingleEnumProperty { get; set; }
            
            [KicadParameter(0)]
            public TestEnum ParameterEnum { get; set; }
        }

        private class EnumTestRootModel : KicadRootModel<EnumTestModel>
        {
            [KicadParserComplexSymbol("root")]
            public override EnumTestModel Root { get; set; } = new EnumTestModel();
        }

        private class EnumTestParser : KicadBaseParser<EnumTestModel, EnumTestRootModel>
        {
            private static readonly TypeCache StaticTypeCache = new TypeCache();
            
            static EnumTestParser()
            {
                StaticTypeCache.LoadCache(new[] { typeof(EnumTestParser).Assembly });
            }

            public EnumTestParser() : base(StaticTypeCache) { }

            protected override bool CheckVersion(EnumTestModel instance)
            {
                return true;
            }
        }

        [Test]
        public void Parse_WithNullEnumValue_SetsToDefaultValue()
        {
            var parser = new EnumTestParser();
            var content = "(root (test_enum))"; // No parameter, simulates null/empty
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.TestEnumProperty, Is.EqualTo(TestEnum.DefaultValue));
        }

        [Test]
        public void Parse_WithEmptyStringEnumValue_SetsToDefaultValue()
        {
            var parser = new EnumTestParser();
            var content = "(root \"\")"; // Empty parameter value
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.DefaultValue));
        }

        [Test]
        public void Parse_WithWhitespaceOnlyEnumValue_SetsToDefaultValue()
        {
            var parser = new EnumTestParser();
            var content = "(root \"   \t\n  \")"; // Whitespace only
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.DefaultValue));
        }

        [Test]
        public void Parse_WithValidExactEnumValue_SetsCorrectValue()
        {
            var parser = new EnumTestParser();
            var content = "(root \"FirstValue\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.FirstValue));
        }

        [Test]
        public void Parse_WithDashSeparatedValue_NormalizesToPascalCase()
        {
            var parser = new EnumTestParser();
            var content = "(root \"dash-dot-value\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.DashDotValue));
        }

        [Test]
        public void Parse_WithUnderscoreSeparatedValue_NormalizesToPascalCase()
        {
            var parser = new EnumTestParser();
            var content = "(root \"snake_case_value\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.Snake_case_value));
        }

        [Test]
        public void Parse_WithLayerNameDotNotation_NormalizesCorrectly()
        {
            var parser = new EnumTestParser();
            var content = "(root \"F.Cu\")"; // Simulates KiCad layer name
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.FCu));
        }

        [Test]
        public void Parse_WithComplexLayerName_NormalizesCorrectly()
        {
            var parser = new EnumTestParser();
            var content = "(root \"B.SilkS\")"; // More complex layer name
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.BSilkS));
        }

        [Test]
        public void Parse_WithMixedCaseValue_HandlesCorrectly()
        {
            var parser = new EnumTestParser();
            var content = "(root \"MiXeDcAsEvAlUe\")"; // Case insensitive parsing
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.mixedCaseValue));
        }

        [Test]
        public void Parse_WithAllUppercaseValue_HandlesCorrectly()
        {
            var parser = new EnumTestParser();
            var content = "(root \"uppercase_value\")"; // Should normalize and match
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // The parser should find UPPERCASE_VALUE as the closest match to "uppercase_value"
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.UPPERCASE_VALUE));
        }

        [Test]
        public void Parse_WithInvalidEnumValue_FallsBackToDefault()
        {
            var parser = new EnumTestParser();
            var content = "(root \"NonExistentEnumValue\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.DefaultValue));
        }

        [Test]
        public void Parse_WithSpecialCharactersInValue_FallsBackToDefault()
        {
            var parser = new EnumTestParser();
            var content = "(root \"!@#$%^&*()\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.DefaultValue));
        }

        [Test]
        public void Parse_WithNumbersInValue_HandlesCorrectly()
        {
            var parser = new EnumTestParser();
            var content = "(root \"with-numbers-1-2-3\")"; // Should normalize to WithNumbers123
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.WithNumbers123));
        }

        [Test]
        public void Parse_WithVeryLongEnumValue_HandlesGracefully()
        {
            var parser = new EnumTestParser();
            var longValue = new string('x', 1000);
            var content = $"(root \"{longValue}\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.DefaultValue));
        }

        [Test]
        public void Parse_WithMultipleSeparatorsInValue_NormalizesCorrectly()
        {
            var parser = new EnumTestParser();
            var content = "(root \"dash-dot__value\")"; // Mixed separators
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Should normalize to DashDotValue
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.DashDotValue));
        }

        [Test]
        public void Parse_WithEmptySegmentsInValue_HandlesGracefully()
        {
            var parser = new EnumTestParser();
            var content = "(root \"--first__value--\")"; // Empty segments from multiple separators
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Should normalize to FirstValue (empty segments ignored)
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.FirstValue));
        }

        [Test]
        public void Parse_WithLeadingTrailingWhitespace_TrimsAndParses()
        {
            var parser = new EnumTestParser();
            var content = "(root \"  FirstValue  \")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.FirstValue));
        }

        [Test]
        public void Parse_WithSingleCharacterValue_HandlesCorrectly()
        {
            var parser = new EnumTestParser();
            var content = "(root \"a\")"; // Single character that won't match any enum
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.DefaultValue));
        }

        [Test]
        public void Parse_WithPartialMatchValue_DoesNotMatchPartially()
        {
            var parser = new EnumTestParser();
            var content = "(root \"First\")"; // Partial match of "FirstValue"
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.DefaultValue));
        }

        [Test]
        public void Parse_WithNormalizedValueThatMatchesExisting_MatchesCorrectly()
        {
            var parser = new EnumTestParser();
            var content = "(root \"first-value\")"; // Should normalize to FirstValue
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterEnum, Is.EqualTo(TestEnum.FirstValue));
        }
    }
}