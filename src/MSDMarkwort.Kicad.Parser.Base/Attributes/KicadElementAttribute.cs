using System;

namespace MSDMarkwort.Kicad.Parser.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KicadElementAttribute : Attribute
    {
        public string ElementName { get; set; }

        public KicadElementAttribute(string elementName)
        {
            ElementName = elementName;
        }
    }
}
