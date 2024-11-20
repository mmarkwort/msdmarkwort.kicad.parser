using System;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection.PropertySetter
{
    internal interface IPropertySetter
    {
        Type TargetType { get; }

        void Set(PropertyInfo targetProperty, object target, string value);
    }
}
