using System;
using System.Globalization;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection.PropertySetter
{
    internal class DoublePropertySetter : IPropertySetter
    {
        public Type TargetType => typeof(double);

        public void Set(PropertyInfo targetProperty, object target, string value)
        {
            var doubleValue = double.Parse(value, CultureInfo.GetCultureInfo("en-US"));

            targetProperty.SetValue(target, doubleValue);
        }
    }
}
