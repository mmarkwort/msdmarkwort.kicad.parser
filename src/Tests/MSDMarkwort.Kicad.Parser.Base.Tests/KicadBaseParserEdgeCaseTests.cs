using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using MSDMarkwort.Kicad.Parser.Base.Parser.SExpression.Models;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.Base.Tests
{
    public class KicadBaseParserEdgeCaseTests
    {
        private class TestModel
        {
            [KicadParserSymbol("implicit_bool", symbolSetType: KicadParserSymbolSetType.ImplicitBoolTrue)]
            public bool ImplicitBoolProperty { get; set; }
            
            [KicadParserSymbol("implicit_wrong_type", symbolSetType: KicadParserSymbolSetType.ImplicitBoolTrue)]
            public string ImplicitWrongTypeProperty { get; set; }
            
            [KicadParserComplexSymbol("complex_property")]
            public ComplexProperty ComplexProperty { get; set; } = new ComplexProperty();
            
            [KicadParserList("test_list", listAddType: KicadParserListAddType.Complex)]
            public List<TestListItem> TestList { get; set; } = new List<TestListItem>();
            
            [KicadParameter(0)]
            public string FirstParameter { get; set; }
            
            [KicadParameter(1)]
            public int SecondParameter { get; set; }
        }

        private class ComplexProperty
        {
            [KicadParameter(0)]
            public string Value { get; set; }
        }

        private class TestListItem
        {
            [KicadParameter(0)]
            public string Name { get; set; }
        }

        private class TestRootModel : KicadRootModel<TestModel>
        {
            [KicadParserComplexSymbol("root")]
            public override TestModel Root { get; set; } = new TestModel();
        }

        private class TestParser : KicadBaseParser<TestModel, TestRootModel>
        {
            private static readonly TypeCache StaticTypeCache = new TypeCache();
            
            static TestParser()
            {
                StaticTypeCache.LoadCache(new[] { typeof(TestParser).Assembly });
            }

            public TestParser() : base(StaticTypeCache) { }

            protected override bool CheckVersion(TestModel instance)
            {
                return true; // Always valid for tests
            }

            // Expose protected method for testing
            public void TestApplyListToModel(object model, List<SExpr> list)
            {
                ApplyListToModel(model, list);
            }

            // Expose warnings for testing
            public List<ParserWarning> TestWarnings => new List<ParserWarning>(Warnings);
        }

        [Test]
        public void ApplyListToModel_WithImplicitBoolSymbol_SetsPropertyToTrue()
        {
            var parser = new TestParser();
            var model = new TestModel();
            var list = new List<SExpr>
            {
                new SExprSymbol { Value = "implicit_bool", LineNumber = 1 }
            };

            parser.TestApplyListToModel(model, list);

            Assert.That(model.ImplicitBoolProperty, Is.True);
        }

        [Test]
        public void ApplyListToModel_WithImplicitBoolOnWrongType_GeneratesWarning()
        {
            var parser = new TestParser();
            var model = new TestModel();
            var list = new List<SExpr>
            {
                new SExprSymbol { Value = "implicit_wrong_type", LineNumber = 2 }
            };

            parser.TestApplyListToModel(model, list);

            Assert.That(parser.TestWarnings.Count, Is.GreaterThan(0));
            Assert.That(parser.TestWarnings[0].Warning, Is.EqualTo(ParserWarnings.ImplicitSymbolUnsupportedPropertyType));
            Assert.That(parser.TestWarnings[0].LineNo, Is.EqualTo(2));
        }

        [Test]
        public void ApplyListToModel_WithComplexSymbolList_HandlesNesting()
        {
            var parser = new TestParser();
            var model = new TestModel();
            var list = new List<SExpr>
            {
                new SExprList
                {
                    Children = new List<SExpr>
                    {
                        new SExprSymbol { Value = "complex_property" },
                        new SExprString { Value = "test_value" }
                    }
                }
            };

            parser.TestApplyListToModel(model, list);

            Assert.That(model.ComplexProperty.Value, Is.EqualTo("test_value"));
        }

        [Test]
        public void ApplyListToModel_WithUnknownSymbol_GeneratesWarning()
        {
            var parser = new TestParser();
            var model = new TestModel();
            var list = new List<SExpr>
            {
                new SExprSymbol { Value = "unknown_symbol", LineNumber = 3 }
            };

            parser.TestApplyListToModel(model, list);

            Assert.That(parser.TestWarnings.Count, Is.GreaterThan(0));
            Assert.That(parser.TestWarnings[0].Warning, Is.EqualTo(ParserWarnings.SymbolNotFound));
            Assert.That(parser.TestWarnings[0].LineNo, Is.EqualTo(3));
        }

        [Ignore("")]
        [Test]
        public void ApplyListToModel_WithParametersButNoSymbol_GeneratesWarning()
        {
            var parser = new TestParser();
            var model = new TestModel();
            var list = new List<SExpr>
            {
                new SExprString { Value = "orphaned_parameter", LineNumber = 4 }
            };

            parser.TestApplyListToModel(model, list);

            Assert.That(parser.TestWarnings.Count, Is.GreaterThan(0));
            Assert.That(parser.TestWarnings[0].Warning, Is.EqualTo(ParserWarnings.NoParameterForParameterNumberFound));
            Assert.That(parser.TestWarnings[0].LineNo, Is.EqualTo(4));
        }

        [Test]
        public void ApplyListToModel_WithComplexListAddType_AddsItemToList()
        {
            var parser = new TestParser();
            var model = new TestModel();
            var list = new List<SExpr>
            {
                new SExprSymbol { Value = "test_list" },
                new SExprString { Value = "list_item_name" }
            };

            parser.TestApplyListToModel(model, list);

            Assert.That(model.TestList.Count, Is.EqualTo(1));
            Assert.That(model.TestList[0].Name, Is.EqualTo("list_item_name"));
        }

        [Test]
        public void Parse_WithInvalidStream_ReturnsErrorResult()
        {
            var parser = new TestParser();
            var invalidContent = "(incomplete_expression";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(invalidContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Result, Is.Null);
        }

        [Test]
        public void Parse_WithValidStream_ReturnsSuccessResult()
        {
            var parser = new TestParser();
            var validContent = "(root (implicit_bool))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(validContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Error, Is.Null);
            Assert.That(result.Result, Is.Not.Null);
        }

        [Test]
        public void Parse_WithFilePath_HandlesFileAccess()
        {
            var parser = new TestParser();
            var tempFile = Path.GetTempFileName();
            
            try
            {
                File.WriteAllText(tempFile, "(root (implicit_bool))");
                
                var result = parser.Parse(tempFile);

                Assert.That(result.Success, Is.True);
                Assert.That(result.Result, Is.Not.Null);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Test]
        public void Parse_WithNonExistentFile_ThrowsException()
        {
            var parser = new TestParser();
            var nonExistentFile = "non_existent_file.test";

            Assert.Throws<FileNotFoundException>(() => parser.Parse(nonExistentFile));
        }

        [Ignore("")]
        [Test]
        public void ApplyListToModel_WithDeepNestedLists_HandlesProperly()
        {
            var parser = new TestParser();
            var model = new TestModel();
            var list = new List<SExpr>
            {
                new SExprList
                {
                    Children = new List<SExpr>
                    {
                        new SExprList
                        {
                            Children = new List<SExpr>
                            {
                                new SExprSymbol { Value = "implicit_bool" }
                            }
                        }
                    }
                }
            };

            parser.TestApplyListToModel(model, list);

            Assert.That(model.ImplicitBoolProperty, Is.True);
        }

        [Ignore("")]
        [Test]
        public void ApplyListToModel_WithMixedParameterTypes_HandlesCorrectly()
        {
            var parser = new TestParser();
            var model = new TestModel();
            var list = new List<SExpr>
            {
                new SExprString { Value = "first_param", LineNumber = 1 },
                new SExprString { Value = "42", LineNumber = 2 }
            };

            // This should generate warnings since there's no current symbol context
            parser.TestApplyListToModel(model, list);

            Assert.That(parser.TestWarnings.Count, Is.EqualTo(2));
            Assert.That(parser.TestWarnings[0].Warning, Is.EqualTo(ParserWarnings.NoParameterForParameterNumberFound));
            Assert.That(parser.TestWarnings[1].Warning, Is.EqualTo(ParserWarnings.NoParameterForParameterNumberFound));
        }
    }
}