using System;
using System.Collections.Generic;
using System.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.Base.Tests
{
    public class GeneralPropertySetterTests
    {
        private enum TestEnum
        {
            Value1,
            Value2
        }

        private class TestClass
        {
            public string StringProperty { get; set; }
            public int IntProperty { get; set; }
            public bool BoolProperty { get; set; }
            public double DoubleProperty { get; set; }
            public Guid GuidProperty { get; set; }
            public byte[] ByteArrayProperty { get; set; }
            public TestEnum EnumProperty { get; set; }
            public DateTime UnsupportedProperty { get; set; }
        }

        private class CustomList : List<string>
        {
        }

        [Test]
        public void IsList_WithGenericList_ReturnsTrue()
        {
            var result = typeof(List<string>).IsList();
            
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsList_WithCustomListDerivedClass_ReturnsTrue()
        {
            var result = typeof(CustomList).IsList();
            
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsList_WithNonListType_ReturnsFalse()
        {
            var result = typeof(string).IsList();
            
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsList_WithObjectType_ReturnsFalse()
        {
            var result = typeof(object).IsList();
            
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsList_WithArrayType_ReturnsFalse()
        {
            var result = typeof(string[]).IsList();
            
            Assert.That(result, Is.False);
        }

        [Test]
        public void GetListGenericType_WithGenericList_ReturnsGenericArgument()
        {
            var result = typeof(List<string>).GetListGenericType();
            
            Assert.That(result, Is.EqualTo(typeof(string)));
        }

        [Test]
        public void GetListGenericType_WithCustomListDerivedClass_ReturnsGenericArgument()
        {
            var result = typeof(CustomList).GetListGenericType();
            
            Assert.That(result, Is.EqualTo(typeof(string)));
        }

        [Test]
        public void GetListGenericType_WithNonListType_ReturnsNull()
        {
            var result = typeof(string).GetListGenericType();
            
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetListGenericType_WithObjectType_ReturnsNull()
        {
            var result = typeof(object).GetListGenericType();
            
            Assert.That(result, Is.Null);
        }

        [Test]
        public void SetProperty_WithStringProperty_SetsValueSuccessfully()
        {
            var testObject = new TestClass();
            var property = typeof(TestClass).GetProperty(nameof(TestClass.StringProperty));
            
            var result = testObject.SetProperty(property, "test value");
            
            Assert.That(result, Is.EqualTo(ParserWarnings.NoWarning));
            Assert.That(testObject.StringProperty, Is.EqualTo("test value"));
        }

        [Test]
        public void SetProperty_WithIntProperty_SetsValueSuccessfully()
        {
            var testObject = new TestClass();
            var property = typeof(TestClass).GetProperty(nameof(TestClass.IntProperty));
            
            var result = testObject.SetProperty(property, "42");
            
            Assert.That(result, Is.EqualTo(ParserWarnings.NoWarning));
            Assert.That(testObject.IntProperty, Is.EqualTo(42));
        }

        [Test]
        public void SetProperty_WithBoolProperty_SetsValueSuccessfully()
        {
            var testObject = new TestClass();
            var property = typeof(TestClass).GetProperty(nameof(TestClass.BoolProperty));
            
            var result = testObject.SetProperty(property, "true");
            
            Assert.That(result, Is.EqualTo(ParserWarnings.NoWarning));
            Assert.That(testObject.BoolProperty, Is.True);
        }

        [Test]
        public void SetProperty_WithEnumProperty_SetsValueSuccessfully()
        {
            var testObject = new TestClass();
            var property = typeof(TestClass).GetProperty(nameof(TestClass.EnumProperty));
            
            var result = testObject.SetProperty(property, "Value1");
            
            Assert.That(result, Is.EqualTo(ParserWarnings.NoWarning));
            Assert.That(testObject.EnumProperty, Is.EqualTo(TestEnum.Value1));
        }

        [Test]
        public void SetProperty_WithUnsupportedPropertyType_ReturnsUnknownSetter()
        {
            var testObject = new TestClass();
            var property = typeof(TestClass).GetProperty(nameof(TestClass.UnsupportedProperty));
            
            var result = testObject.SetProperty(property, "2023-01-01");
            
            Assert.That(result, Is.EqualTo(ParserWarnings.UnknownSetter));
        }

        [Test]
        public void SetProperty_WithInvalidValue_ReturnsParameterSetFailed()
        {
            var testObject = new TestClass();
            var property = typeof(TestClass).GetProperty(nameof(TestClass.IntProperty));
            
            var result = testObject.SetProperty(property, "invalid_integer");
            
            Assert.That(result, Is.EqualTo(ParserWarnings.ParameterSetFailed));
        }

        [Test]
        public void SetProperty_WithInvalidEnumValue_FallsBackToFirstValue()
        {
            var testObject = new TestClass();
            var property = typeof(TestClass).GetProperty(nameof(TestClass.EnumProperty));
            
            var result = testObject.SetProperty(property, "InvalidEnumValue");
            
            Assert.That(result, Is.EqualTo(ParserWarnings.NoWarning));
            Assert.That(testObject.EnumProperty, Is.EqualTo(TestEnum.Value1)); // Should fallback to first enum value
        }

        [Test]
        public void SetProperty_WithGuidProperty_SetsValueSuccessfully()
        {
            var testObject = new TestClass();
            var property = typeof(TestClass).GetProperty(nameof(TestClass.GuidProperty));
            var guidString = "12345678-1234-1234-1234-123456789012";
            
            var result = testObject.SetProperty(property, guidString);
            
            Assert.That(result, Is.EqualTo(ParserWarnings.NoWarning));
            Assert.That(testObject.GuidProperty, Is.EqualTo(Guid.Parse(guidString)));
        }

        [Test]
        public void SetProperty_WithInvalidGuid_ReturnsParameterSetFailed()
        {
            var testObject = new TestClass();
            var property = typeof(TestClass).GetProperty(nameof(TestClass.GuidProperty));
            
            var result = testObject.SetProperty(property, "invalid-guid");
            
            Assert.That(result, Is.EqualTo(ParserWarnings.ParameterSetFailed));
        }
    }
}