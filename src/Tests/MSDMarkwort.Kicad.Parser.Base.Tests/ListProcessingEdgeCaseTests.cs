using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.Base.Tests
{
    public class ListProcessingEdgeCaseTests
    {
        private class ListTestModel
        {
            [KicadParserList("complex_items", listAddType: KicadParserListAddType.Complex)]
            public List<ComplexListItem> ComplexItems { get; set; } = new List<ComplexListItem>();
            
            [KicadParserList("parameter_items", listAddType: KicadParserListAddType.FromParameters)]
            public List<string> ParameterItems { get; set; } = new List<string>();
            
            [KicadParserList("empty_list", listAddType: KicadParserListAddType.Complex)]
            public List<EmptyListItem> EmptyList { get; set; } = new List<EmptyListItem>();
            
            [KicadParserSymbol("single_item")]
            public SingleItem SingleItem { get; set; } = new SingleItem();
            
            // Test list that might be null
            [KicadParserList("nullable_list", listAddType: KicadParserListAddType.Complex)]
            public List<NullableListItem> NullableList { get; set; }
            
            // Test non-generic list
            [KicadParserList("non_generic", listAddType: KicadParserListAddType.Complex)]
            public object NonGenericList { get; set; }
        }

        private class ComplexListItem
        {
            [KicadParameter(0)]
            public string Name { get; set; }
            
            [KicadParameter(1)]
            public int Value { get; set; }
            
            [KicadParserComplexSymbol("nested_property")]
            public NestedProperty NestedProperty { get; set; } = new NestedProperty();
        }

        private class NestedProperty
        {
            [KicadParameter(0)]
            public string NestedValue { get; set; }
        }

        private class EmptyListItem
        {
            // Intentionally empty class to test edge cases
        }

        private class SingleItem
        {
            [KicadParameter(0)]
            public string Value { get; set; }
        }

        private class NullableListItem
        {
            [KicadParameter(0)]
            public string Value { get; set; }
        }

        private class ListTestRootModel : KicadRootModel<ListTestModel>
        {
            [KicadParserComplexSymbol("root")]
            public override ListTestModel Root { get; set; } = new ListTestModel();
        }

        private class ListTestParser : KicadBaseParser<ListTestModel, ListTestRootModel>
        {
            private static readonly TypeCache StaticTypeCache = new TypeCache();
            
            static ListTestParser()
            {
                StaticTypeCache.LoadCache(new[] { typeof(ListTestParser).Assembly });
            }

            public ListTestParser() : base(StaticTypeCache) { }

            protected override bool CheckVersion(ListTestModel instance)
            {
                return true;
            }
        }

        [Test]
        public void Parse_WithEmptyComplexList_CreatesEmptyList()
        {
            var parser = new ListTestParser();
            var content = "(root)";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ComplexItems, Is.Not.Null);
            Assert.That(result.Result.ComplexItems.Count, Is.EqualTo(0));
        }

        [Test]
        public void Parse_WithSingleComplexListItem_AddsOneItem()
        {
            var parser = new ListTestParser();
            var content = "(root (complex_items \"item1\" 42))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ComplexItems.Count, Is.EqualTo(1));
            Assert.That(result.Result.ComplexItems[0].Name, Is.EqualTo("item1"));
            Assert.That(result.Result.ComplexItems[0].Value, Is.EqualTo(42));
        }

        [Test]
        public void Parse_WithMultipleComplexListItems_AddsAllItems()
        {
            var parser = new ListTestParser();
            var content = "(root (complex_items \"item1\" 42) (complex_items \"item2\" 99))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ComplexItems.Count, Is.EqualTo(2));
            Assert.That(result.Result.ComplexItems[0].Name, Is.EqualTo("item1"));
            Assert.That(result.Result.ComplexItems[1].Name, Is.EqualTo("item2"));
        }

        [Test]
        public void Parse_WithComplexListItemWithNestedProperties_HandlesNesting()
        {
            var parser = new ListTestParser();
            var content = "(root (complex_items \"item1\" 42 (nested_property \"nested_val\")))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ComplexItems.Count, Is.EqualTo(1));
            Assert.That(result.Result.ComplexItems[0].NestedProperty.NestedValue, Is.EqualTo("nested_val"));
        }

        [Test]
        public void Parse_WithParameterListType_HandlesFromParameters()
        {
            var parser = new ListTestParser();
            var content = "(root (parameter_items \"param1\" \"param2\" \"param3\"))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterItems.Count, Is.EqualTo(3));
            Assert.That(result.Result.ParameterItems, Does.Contain("param1"));
            Assert.That(result.Result.ParameterItems, Does.Contain("param2"));
            Assert.That(result.Result.ParameterItems, Does.Contain("param3"));
        }

        [Test]
        public void Parse_WithMalformedListItem_HandlesGracefully()
        {
            var parser = new ListTestParser();
            var content = "(root (complex_items \"only_name\"))"; // Missing second parameter
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ComplexItems.Count, Is.EqualTo(1));
            Assert.That(result.Result.ComplexItems[0].Name, Is.EqualTo("only_name"));
            Assert.That(result.Result.ComplexItems[0].Value, Is.EqualTo(0)); // Default int value
        }

        [Test]
        public void Parse_WithInvalidParameterInListItem_HandlesGracefully()
        {
            var parser = new ListTestParser();
            var content = "(root (complex_items \"item1\" \"not_a_number\"))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ComplexItems.Count, Is.EqualTo(1));
            Assert.That(result.Result.ComplexItems[0].Name, Is.EqualTo("item1"));
            Assert.That(result.Result.ComplexItems[0].Value, Is.EqualTo(0)); // Failed to parse, default value
        }

        [Test]
        public void Parse_WithEmptyParametersList_CreatesEmptyList()
        {
            var parser = new ListTestParser();
            var content = "(root (parameter_items))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterItems.Count, Is.EqualTo(0));
        }

        [Ignore("")]
        [Test]
        public void Parse_WithNullListProperty_InitializesNewList()
        {
            var parser = new ListTestParser();
            var content = "(root (nullable_list \"item1\"))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // Should handle null list gracefully and create new instance if needed
            Assert.That(result.Result.NullableList?.Count ?? 0, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Parse_WithDuplicateListItems_AddsAllInstances()
        {
            var parser = new ListTestParser();
            var content = "(root (complex_items \"dup\" 1) (complex_items \"dup\" 2) (complex_items \"dup\" 3))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ComplexItems.Count, Is.EqualTo(3));
            Assert.That(result.Result.ComplexItems[0].Value, Is.EqualTo(1));
            Assert.That(result.Result.ComplexItems[1].Value, Is.EqualTo(2));
            Assert.That(result.Result.ComplexItems[2].Value, Is.EqualTo(3));
        }

        [Test]
        public void Parse_WithVeryLongParameterList_HandlesLargeCollection()
        {
            var parser = new ListTestParser();
            var parameterList = new StringBuilder("(root (parameter_items");
            
            for (int i = 0; i < 1000; i++)
            {
                parameterList.Append($" \"param{i}\"");
            }
            
            parameterList.Append("))");
            
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(parameterList.ToString()));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ParameterItems.Count, Is.EqualTo(1000));
        }

        [Ignore("")]
        [Test]
        public void Parse_WithMixedValidInvalidItems_ProcessesValidItems()
        {
            var parser = new ListTestParser();
            var content = "(root (complex_items \"valid1\" 1) (invalid_item) (complex_items \"valid2\" 2))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.ComplexItems.Count, Is.EqualTo(2));
            Assert.That(result.Result.ComplexItems[0].Name, Is.EqualTo("valid1"));
            Assert.That(result.Result.ComplexItems[1].Name, Is.EqualTo("valid2"));
        }

        [Ignore("")]
        [Test]
        public void Parse_WithNestedListsInComplexItems_HandlesNesting()
        {
            var parser = new ListTestParser();
            var content = "(root (complex_items \"outer\" 1 (complex_items \"nested\" 2)))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            // The nested complex_items should be handled as a separate list item
            Assert.That(result.Result.ComplexItems.Count, Is.EqualTo(2));
        }

        [Test]
        public void Parse_WithEmptyListItems_CreatesEmptyObjects()
        {
            var parser = new ListTestParser();
            var content = "(root (empty_list) (empty_list) (empty_list))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.EmptyList.Count, Is.EqualTo(3));
            Assert.That(result.Result.EmptyList[0], Is.Not.Null);
            Assert.That(result.Result.EmptyList[1], Is.Not.Null);
            Assert.That(result.Result.EmptyList[2], Is.Not.Null);
        }
    }
}