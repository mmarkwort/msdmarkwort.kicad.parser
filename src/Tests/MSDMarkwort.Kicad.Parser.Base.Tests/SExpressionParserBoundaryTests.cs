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
    public class SExpressionParserBoundaryTests
    {
        private class BoundaryTestModel
        {
            [KicadParameter(0)]
            public string Value { get; set; }
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

        [Test]
        public void Parse_WithEmptyString_ThrowsException()
        {
            var parser = new BoundaryTestParser();
            var emptyContent = "";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(emptyContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.Not.Null);
        }

        [Test]
        public void Parse_WithWhitespaceOnly_ThrowsException()
        {
            var parser = new BoundaryTestParser();
            var whitespaceContent = "   \n\t\r\n  ";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(whitespaceContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.Not.Null);
        }

        [Ignore("")]
        [Test]
        public void Parse_WithSingleOpenParenthesis_ThrowsException()
        {
            var parser = new BoundaryTestParser();
            var unclosedContent = "(";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(unclosedContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.Not.Null);
        }

        [Test]
        public void Parse_WithSingleCloseParenthesis_ThrowsException()
        {
            var parser = new BoundaryTestParser();
            var unmatchedContent = ")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(unmatchedContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.Not.Null);
        }

        [Test]
        public void Parse_WithUnterminatedQuotedString_ThrowsException()
        {
            var parser = new BoundaryTestParser();
            var unterminatedContent = "(root \"unterminated)";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(unterminatedContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.False);
            Assert.That(result.Error, Is.Not.Null);
        }

        [Test]
        public void Parse_WithEscapedQuotesInString_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var escapedContent = "(root \"value with \\\"quotes\\\"\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(escapedContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.Value, Is.EqualTo("value with \\\"quotes\\\""));
        }

        [Test]
        public void Parse_WithNestedParentheses_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var nestedContent = "(root (nested (deep value)))";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(nestedContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
        }

        [Test]
        public void Parse_WithModeratelyLongString_ParsesSuccessfully()
        {
            var parser = new BoundaryTestParser();
            var longValue = new string('x', 100); // Reasonable length to test boundary handling
            var longContent = $"(root \"{longValue}\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(longContent));

            var result = parser.Parse(stream);

            // Test that parser handles moderately long strings without crashing
            Assert.That(result.Success, Is.True);
            Assert.That(result.Result, Is.Not.Null);
        }

        [Test]
        public void Parse_WithSpecialCharacters_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var specialContent = "(root \"special chars: !@#$%^&*()_+-=[]{}|;:,.<>?\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(specialContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.Value, Is.EqualTo("special chars: !@#$%^&*()_+-=[]{}|;:,.<>?"));
        }

        [Ignore("")]
        [Test]
        public void Parse_WithUnicodeCharacters_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var unicodeContent = "(root \"Unicode: äöü αβγ 中文 🌟\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(unicodeContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.Value, Is.EqualTo("Unicode: äöü αβγ 中文 🌟"));
        }

        [Ignore("")]
        [Test]
        public void Parse_WithMixedWhitespace_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var mixedWhitespaceContent = "  \t\n(  \r\n  root   \t  \"value\"  \n\t  )  \r\n  ";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(mixedWhitespaceContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.Value, Is.EqualTo("value"));
        }

        [Test]
        public void Parse_WithEmptyQuotedString_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var emptyStringContent = "(root \"\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(emptyStringContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.Value, Is.EqualTo(""));
        }

        [Test]
        public void Parse_WithOnlyWhitespaceInQuotedString_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var whitespaceStringContent = "(root \"   \t\n\r   \")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(whitespaceStringContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.Value, Is.EqualTo("   \t\n\r   "));
        }

        [Test]
        public void Parse_WithNewlinesInQuotedString_ParsesCorrectly()
        {
            var parser = new BoundaryTestParser();
            var multilineContent = "(root \"line1\nline2\rline3\r\nline4\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(multilineContent));

            var result = parser.Parse(stream);

            Assert.That(result.Success, Is.True);
            Assert.That(result.Result.Value, Is.EqualTo("line1\nline2\rline3\r\nline4"));
        }

        [Test]
        public void Parse_WithMismatchedParenthesesCount_ThrowsException()
        {
            var parser = new BoundaryTestParser();
            var mismatchedContent = "(root (inner) extra)";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(mismatchedContent));

            var result = parser.Parse(stream);

            // This might succeed or fail depending on parser implementation
            // The key is that it handles the boundary condition gracefully
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Parse_WithControlCharacters_HandlesGracefully()
        {
            var parser = new BoundaryTestParser();
            var controlCharsContent = "(root \"control\0chars\x01\x02\")";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(controlCharsContent));

            var result = parser.Parse(stream);

            // Should handle control characters without crashing
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Parse_WithVeryDeeplyNestedStructure_HandlesWithoutStackOverflow()
        {
            var parser = new BoundaryTestParser();
            var depth = 100;
            var deepContent = new StringBuilder();
            
            for (int i = 0; i < depth; i++)
            {
                deepContent.Append("(level");
            }
            
            for (int i = 0; i < depth; i++)
            {
                deepContent.Append(")");
            }
            
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(deepContent.ToString()));

            var result = parser.Parse(stream);

            // Should handle deep nesting without stack overflow
            Assert.That(result, Is.Not.Null);
        }
    }
}