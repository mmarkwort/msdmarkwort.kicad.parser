using System;
using MSDMarkwort.Kicad.Parser.Base.Parser.Exception;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.Base.Tests
{
    public class ParserExceptionTests
    {
        [Test]
        public void Constructor_WithLineNumberAndInnerException_SetsPropertiesCorrectly()
        {
            var innerException = new InvalidOperationException("Inner error");
            var lineNumber = 42;
            
            var parserException = new ParserException(lineNumber, innerException);
            
            Assert.That(parserException.LineNumber, Is.EqualTo(lineNumber));
            Assert.That(parserException.InnerException, Is.EqualTo(innerException));
            Assert.That(parserException.Message, Is.EqualTo("Fatal parsing error. See inner exceptions for details."));
        }

        [Test]
        public void Constructor_WithZeroLineNumber_SetsLineNumberCorrectly()
        {
            var innerException = new ArgumentException("Test error");
            
            var parserException = new ParserException(0, innerException);
            
            Assert.That(parserException.LineNumber, Is.EqualTo(0));
            Assert.That(parserException.InnerException, Is.EqualTo(innerException));
        }

        [Test]
        public void Constructor_WithNegativeLineNumber_SetsLineNumberCorrectly()
        {
            var innerException = new FormatException("Test error");
            
            var parserException = new ParserException(-1, innerException);
            
            Assert.That(parserException.LineNumber, Is.EqualTo(-1));
            Assert.That(parserException.InnerException, Is.EqualTo(innerException));
        }

        [Test]
        public void Constructor_WithNullInnerException_SetsInnerExceptionToNull()
        {
            var parserException = new ParserException(10, null);
            
            Assert.That(parserException.LineNumber, Is.EqualTo(10));
            Assert.That(parserException.InnerException, Is.Null);
            Assert.That(parserException.Message, Is.EqualTo("Fatal parsing error. See inner exceptions for details."));
        }

        [Test]
        public void LineNumber_PropertyAccess_ReturnsCorrectValue()
        {
            var lineNumber = 123;
            var parserException = new ParserException(lineNumber, new Exception());
            
            var retrievedLineNumber = parserException.LineNumber;
            
            Assert.That(retrievedLineNumber, Is.EqualTo(lineNumber));
        }

        [Test]
        public void ParserException_CanBeThrown_AndCaught()
        {
            var lineNumber = 99;
            var innerException = new NotImplementedException("Test");
            
            Assert.Throws<ParserException>(() =>
            {
                throw new ParserException(lineNumber, innerException);
            });
        }

        [Test]
        public void ParserException_InheritanceChain_IsCorrect()
        {
            var parserException = new ParserException(1, new Exception());
            
            Assert.That(parserException, Is.InstanceOf<Exception>());
            Assert.That(parserException, Is.InstanceOf<ParserException>());
        }
    }
}