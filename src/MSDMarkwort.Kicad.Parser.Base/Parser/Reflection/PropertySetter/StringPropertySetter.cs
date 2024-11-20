using System;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection.PropertySetter
{
    internal class StringPropertySetter : IPropertySetter
    {
        public Type TargetType => typeof(string);

        public void Set(PropertyInfo targetProperty, object target, string value)
        {
            targetProperty.SetValue(target, value);
        }
    }
}
