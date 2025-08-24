using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Parser.SExpression.Models;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.Base.Tests
{
    public class SExprToStringTests
    {
        [Test]
        public void SExprSymbol_ToString_ReturnsFormattedString()
        {
            var symbol = new SExprSymbol
            {
                Value = "test_symbol",
                LineNumber = 42
            };
            
            var result = symbol.ToString();
            
            Assert.That(result, Is.EqualTo("Value: test_symbol (Symbol), Line: 42"));
        }

        [Test]
        public void SExprSymbol_ToStringWithNullValue_HandlesGracefully()
        {
            var symbol = new SExprSymbol
            {
                Value = null,
                LineNumber = 10
            };
            
            var result = symbol.ToString();
            
            Assert.That(result, Is.EqualTo("Value:  (Symbol), Line: 10"));
        }

        [Test]
        public void SExprSymbol_ToStringWithEmptyValue_HandlesGracefully()
        {
            var symbol = new SExprSymbol
            {
                Value = "",
                LineNumber = 0
            };
            
            var result = symbol.ToString();
            
            Assert.That(result, Is.EqualTo("Value:  (Symbol), Line: 0"));
        }

        [Test]
        public void SExprString_ToString_ReturnsFormattedString()
        {
            var exprString = new SExprString
            {
                Value = "test string",
                LineNumber = 15
            };
            
            var result = exprString.ToString();
            
            Assert.That(result, Is.EqualTo("Value: test string (String), Line: 15"));
        }

        [Test]
        public void SExprString_ToStringWithSpecialCharacters_HandlesCorrectly()
        {
            var exprString = new SExprString
            {
                Value = "test\nstring\twith\"quotes",
                LineNumber = 20
            };
            
            var result = exprString.ToString();
            
            Assert.That(result, Is.EqualTo("Value: test\nstring\twith\"quotes (String), Line: 20"));
        }

        [Test]
        public void SExprList_ToString_ReturnsFormattedString()
        {
            var list = new SExprList
            {
                LineNumber = 5
            };
            list.Children.Add(new SExprSymbol { Value = "child1" });
            list.Children.Add(new SExprString { Value = "child2" });
            
            var result = list.ToString();
            
            Assert.That(result, Is.EqualTo("Children: 2, Line: 5"));
        }

        [Test]
        public void SExprList_ToStringWithEmptyChildren_ReturnsZeroCount()
        {
            var list = new SExprList
            {
                LineNumber = 100,
                Children = new List<SExpr>()
            };
            
            var result = list.ToString();
            
            Assert.That(result, Is.EqualTo("Children: 0, Line: 100"));
        }

        [Test]
        public void SExprList_ToStringWithNegativeLineNumber_HandlesGracefully()
        {
            var list = new SExprList
            {
                LineNumber = -1
            };
            list.Children.Add(new SExprSymbol { Value = "test" });
            
            var result = list.ToString();
            
            Assert.That(result, Is.EqualTo("Children: 1, Line: -1"));
        }

        [Test]
        public void SExprTypes_EnumValues_AreCorrect()
        {
            Assert.That((int)SExprTypes.List, Is.EqualTo(0));
            Assert.That((int)SExprTypes.Symbol, Is.EqualTo(1));
            Assert.That((int)SExprTypes.String, Is.EqualTo(2));
        }
    }
}