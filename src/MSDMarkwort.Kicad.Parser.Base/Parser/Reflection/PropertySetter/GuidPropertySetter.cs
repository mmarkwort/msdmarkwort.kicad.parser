using System;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection.PropertySetter
{
    internal class GuidPropertySetter : IPropertySetter
    {
        public Type TargetType => typeof(Guid);

        public void Set(PropertyInfo targetProperty, object target, string value)
        {
            targetProperty.SetValue(target, Guid.Parse(value));
        }
    }
}
