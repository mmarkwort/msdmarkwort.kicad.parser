using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection.PropertySetter;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection
{
    public static class GeneralPropertySetter
    {
        private static readonly IPropertySetter[] PropertySetters =
        {
            new StringPropertySetter(),
            new BooleanPropertySetter(),
            new DoublePropertySetter(),
            new IntPropertySetter(),
            new GuidPropertySetter(),
            new ByteArrayPropertySetter()
        };

        public static ParserWarnings SetProperty(this object target, PropertyInfo propertyInfo, string value)
        {
            var propertySetter = PropertySetters.FirstOrDefault(s => s.TargetType == propertyInfo.PropertyType);
            if (propertySetter == null)
            {
                return ParserWarnings.UnknownSetter;
            }

            try
            {
                propertySetter.Set(propertyInfo, target, value);
            }
            catch (System.Exception)
            {
                return ParserWarnings.ParameterSetFailed;
            }

            return ParserWarnings.NoWarning;
        }

        public static bool IsList(this Type type)
        {
            var currentType = type;

            while (currentType != null && type != typeof(object))
            {
                var isList = currentType.IsGenericType && currentType.GetGenericTypeDefinition() == typeof(List<>);
                if (isList)
                {
                    return true;
                }

                currentType = currentType.BaseType;
            }

            return false;
        }

        public static Type GetListGenericType(this Type type)
        {
            var currentType = type;

            while (currentType != null && type != typeof(object))
            {
                var isList = currentType.IsGenericType && currentType.GetGenericTypeDefinition() == typeof(List<>);
                if (isList)
                {
                    return currentType.GenericTypeArguments.First();
                }

                currentType = currentType.BaseType;
            }

            return null;
        }
    }
}
