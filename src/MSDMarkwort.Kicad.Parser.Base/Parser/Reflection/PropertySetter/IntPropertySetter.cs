using System;
using System.Globalization;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection.PropertySetter
{
    internal class IntPropertySetter : IPropertySetter
    {
        public Type TargetType => typeof(int);

        public void Set(PropertyInfo targetProperty, object target, string value)
        {
            var intValue = int.Parse(value, CultureInfo.GetCultureInfo("en-US"));

            targetProperty.SetValue(target, intValue);
        }
    }
}
