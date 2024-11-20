using System;

namespace MSDMarkwort.Kicad.Parser.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KicadParameterAttribute : Attribute
    {
        public int Number { get; set; }

        public KicadParameterAttribute(int number)
        {
            Number = number;
        }
    }
}
