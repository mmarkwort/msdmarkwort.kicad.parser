using System;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection.PropertySetter
{
    internal class BooleanPropertySetter : IPropertySetter
    {
        public Type TargetType => typeof(bool);

        public void Set(PropertyInfo targetProperty, object target, string value)
        {
            bool boolean = value == "yes";

            targetProperty.SetValue(target, boolean);
        }
    }
}
