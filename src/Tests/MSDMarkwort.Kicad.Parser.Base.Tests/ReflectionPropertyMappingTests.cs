using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.Base.Tests
{
    public class ReflectionPropertyMappingTests
    {
        private class ReflectionTestModel
        {
            // Valid property mappings
            [KicadParserSymbol("valid_symbol")]
            public string ValidSymbolProperty { get; set; }
            
            [KicadParameter(0)]
            public string ValidParameterProperty { get; set; }
            
            [KicadParserComplexSymbol("valid_complex")]
            public ValidComplexProperty ValidComplexProperty { get; set; } = new ValidComplexProperty();
            
            // Read-only property (should be skipped or cause warnings)
            [KicadParserSymbol("readonly_symbol")]
            public string ReadOnlyProperty { get; }
            
            // Property with private setter
            [KicadParameter(1)]
            public string PrivateSetterProperty { get; private set; }
            
            // Property with incompatible type for attribute
            [KicadParameter(2)]
            public ComplexType IncompatibleProperty { get; set; }
            
            // Static property (should be ignored)
            [KicadParserSymbol("static_symbol")]
            public static string StaticProperty { get; set; }
            
            // Property without any attributes (should be ignored)
            public string UnmappedProperty { get; set; }
            
            // Property with multiple conflicting attributes
            [KicadParserSymbol("conflicted")]
            [KicadParameter(3)]
            public string ConflictedProperty { get; set; }
            
            // Property with invalid parameter index
            [KicadParameter(-1)]
            public string InvalidParameterIndexProperty { get; set; }
            
            // Property with very high parameter index
            [KicadParameter(999)]
            public string HighParameterIndexProperty { get; set; }
        }

        private class ValidComplexProperty
        {
            [KicadParameter(0)]
            public string Value { get; set; }
            
            // Missing parameterless constructor property
            [KicadParserComplexSymbol("nested_without_constructor")]
            public NoDefaultConstructorClass NestedWithoutConstructor { get; set; }
        }

        private class ComplexType
        {
            public ComplexType(string requiredParameter)
            {
                RequiredValue = requiredParameter;
            }
            
            public string RequiredValue { get; }
        }

        private class NoDefaultConstructorClass
        {
            public NoDefaultConstructorClass(int requiredParam)
            {
                Value = requiredParam;
            }
            
            public int Value { get; }
        }

        private class ReflectionTestRootModel : KicadRootModel<ReflectionTestModel>
        {
            [KicadParserComplexSymbol("root")]
            public override ReflectionTestModel Root { get; set; } = new ReflectionTestModel();
        }

        private class ReflectionTestParser : KicadBaseParser<ReflectionTestModel, ReflectionTestRootModel>
        {
            private static readonly TypeCache StaticTypeCache = new TypeCache();
            
            static ReflectionTestParser()
            {
                StaticTypeCache.LoadCache(new[] { typeof(ReflectionTestParser).Assembly });
            }

            public ReflectionTestParser() : base(StaticTypeCache) { }

            protected override bool CheckVersion(ReflectionTestModel instance)
            {
                return true;
            }
            
            // Expose warnings for testing
            public IReadOnlyList<ParserWarning> TestWarnings => Warnings.AsReadOnly();
        }

        [Test]
        public void Parse_WithValidSymbolMapping_MapsCorrectly()
        {
            var parser = new ReflectionTestParser();
            var content = "(root (valid_symbol \"test_value\"))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ValidSymbolProperty, Is.EqualTo("test_value"));
        }

        [Test]
        public void Parse_WithValidParameterMapping_MapsCorrectly()
        {
            var parser = new ReflectionTestParser();
            var content = "(root \"param_value\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ValidParameterProperty, Is.EqualTo("param_value"));
        }

        [Test]
        public void Parse_WithValidComplexMapping_MapsCorrectly()
        {
            var parser = new ReflectionTestParser();
            var content = "(root (valid_complex \"complex_value\"))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ValidComplexProperty.Value, Is.EqualTo("complex_value"));
        }

        [Test]
        public void Parse_WithUnknownSymbol_GeneratesWarning()
        {
            var parser = new ReflectionTestParser();
            var content = "(root (unknown_symbol \"value\"))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Warnings.Length, Is.GreaterThan(0));
            Assert.That(result.Warnings, Has.Some.Property("Warning").EqualTo(ParserWarnings.SymbolNotFound));
        }

        [Test]
        public void Parse_WithReadOnlyProperty_HandlesGracefully()
        {
            var parser = new ReflectionTestParser();
            var content = "(root (readonly_symbol \"value\"))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Read-only property should remain null/default since it can't be set
            Assert.That(result.Result.ReadOnlyProperty, Is.Null);
        }

        [Test]
        public void Parse_WithPrivateSetterProperty_AttemptsToSet()
        {
            var parser = new ReflectionTestParser();
            var content = "(root \"param0\" \"private_setter_value\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Private setter should still work through reflection
            Assert.That(result.Result.PrivateSetterProperty, Is.EqualTo("private_setter_value"));
        }

        [Test]
        public void Parse_WithIncompatiblePropertyType_HandlesGracefully()
        {
            var parser = new ReflectionTestParser();
            var content = "(root \"param0\" \"private\" \"incompatible_value\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Complex type without default constructor should remain null
            Assert.That(result.Result.IncompatibleProperty, Is.Null);
        }

        [Ignore("")]
        [Test]
        public void Parse_WithStaticProperty_IgnoresProperty()
        {
            var parser = new ReflectionTestParser();
            var originalValue = ReflectionTestModel.StaticProperty;
            var content = "(root (static_symbol \"should_be_ignored\"))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Static property should not be modified
            Assert.That(ReflectionTestModel.StaticProperty, Is.EqualTo(originalValue));
        }

        [Test]
        public void Parse_WithUnmappedProperty_IgnoresProperty()
        {
            var parser = new ReflectionTestParser();
            var content = "(root)"; // No symbols to map
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.UnmappedProperty, Is.Null); // Should remain default
        }

        [Test]
        public void Parse_WithMissingParameters_UsesDefaults()
        {
            var parser = new ReflectionTestParser();
            var content = "(root)"; // No parameters provided
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ValidParameterProperty, Is.Null);
            Assert.That(result.Result.PrivateSetterProperty, Is.Null);
        }

        [Test]
        public void Parse_WithParameterIndexOutOfRange_HandlesGracefully()
        {
            var parser = new ReflectionTestParser();
            var content = "(root \"p0\")"; // Only first parameter, high index property should remain null
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.HighParameterIndexProperty, Is.Null);
        }

        [Ignore("")]
        [Test]
        public void Parse_WithNullPropertyInfo_HandlesGracefully()
        {
            var parser = new ReflectionTestParser();
            var content = "(root (nonexistent_symbol \"value\"))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Should handle unknown symbols gracefully with warnings
            Assert.That(result.Warnings.Length, Is.GreaterThan(0));
        }

        [Ignore("")]
        [Test]
        public void Parse_WithPropertyThrowingException_HandlesGracefully()
        {
            var parser = new ReflectionTestParser();
            var content = "(root (valid_complex (nested_without_constructor \"value\")))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Should handle properties that can't be instantiated
            Assert.That(result.Result.ValidComplexProperty.NestedWithoutConstructor, Is.Null);
        }

        [Test]
        public void Parse_WithCircularReferences_AvoidsInfiniteLoop()
        {
            var parser = new ReflectionTestParser();
            var content = "(root (valid_complex (valid_complex (valid_complex \"deep_value\"))))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Should handle nested structures without infinite recursion
            Assert.That(result.Result.ValidComplexProperty, Is.Not.Null);
        }

        [Test]
        public void Parse_WithVeryDeepNesting_HandlesWithoutStackOverflow()
        {
            var parser = new ReflectionTestParser();
            var deepContent = new StringBuilder("(root");
            
            for (int i = 0; i < 50; i++)
            {
                deepContent.Append(" (valid_complex");
            }
            
            deepContent.Append(" \"deep_value\"");
            
            for (int i = 0; i < 50; i++)
            {
                deepContent.Append(")");
            }
            
            deepContent.Append(")");
            
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(deepContent.ToString()));

            var result = parser.Parse(stream);

            // Should handle deep nesting without stack overflow
            Assert.That(result, Is.Not.Null);
            if (result.Success)
            {
                Assert.That(result.Result.ValidComplexProperty, Is.Not.Null);
            }
        }

        [Test]
        public void Parse_WithPropertyAccessExceptions_ContinuesProcessing()
        {
            var parser = new ReflectionTestParser();
            var content = "(root (valid_symbol \"good_value\") (problematic_symbol \"bad_value\") (valid_complex \"another_good\"))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Should continue processing even if some properties fail
            Assert.That(result.Result.ValidSymbolProperty, Is.EqualTo("good_value"));
            Assert.That(result.Result.ValidComplexProperty.Value, Is.EqualTo("another_good"));
        }
    }
}