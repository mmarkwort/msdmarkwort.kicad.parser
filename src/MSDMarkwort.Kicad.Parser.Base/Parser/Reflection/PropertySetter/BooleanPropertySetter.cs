using System;
using System.Linq;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection.PropertySetter
{
    internal class BooleanPropertySetter : IPropertySetter
    {
        private readonly string[] _trueValues = new[] { "true", "locked", "hide" };

        public Type TargetType => typeof(bool);

        public void Set(PropertyInfo targetProperty, object target, string value)
        {
            var boolean = _trueValues.Contains(value);

            targetProperty.SetValue(target, boolean);
        }
    }
}
