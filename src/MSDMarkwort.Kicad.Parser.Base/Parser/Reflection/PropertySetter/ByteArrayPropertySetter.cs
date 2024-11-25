using System;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection.PropertySetter
{
    internal class ByteArrayPropertySetter : IPropertySetter
    {
        public Type TargetType => typeof(byte[]);

        public void Set(PropertyInfo targetProperty, object target, string value)
        {
            targetProperty.SetValue(target, Convert.FromBase64String(value));
        }
    }
}
