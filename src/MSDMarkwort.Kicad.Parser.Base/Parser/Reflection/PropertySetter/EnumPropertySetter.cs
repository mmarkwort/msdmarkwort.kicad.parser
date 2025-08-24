using System;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection.PropertySetter
{
    internal class EnumPropertySetter : IPropertySetter
    {
        private readonly Type _enumType;

        public EnumPropertySetter(Type enumType)
        {
            _enumType = enumType ?? throw new ArgumentNullException(nameof(enumType));
            if (!enumType.IsEnum)
                throw new ArgumentException("Type must be an enum", nameof(enumType));
        }

        public Type TargetType => _enumType;

        public void Set(PropertyInfo targetProperty, object target, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                targetProperty.SetValue(target, Enum.GetValues(_enumType).GetValue(0));
                return;
            }

            // Try direct parsing first
            if (Enum.TryParse(_enumType, value, true, out var enumValue))
            {
                targetProperty.SetValue(target, enumValue);
                return;
            }

            // Convert dash_dot format to DashDot format for enum names
            var normalizedValue = NormalizeEnumName(value);
            if (Enum.TryParse(_enumType, normalizedValue, true, out enumValue))
            {
                targetProperty.SetValue(target, enumValue);
                return;
            }

            // Fallback to first enum value if parsing fails
            targetProperty.SetValue(target, Enum.GetValues(_enumType).GetValue(0));
        }

        private string NormalizeEnumName(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            // Handle layer names like "F.Cu" -> "FCu", "B.SilkS" -> "BSilkS"
            value = value.Replace(".", "");

            // Convert snake_case/kebab-case to PascalCase
            var parts = value.Split('_', '-');
            var result = string.Empty;
            
            foreach (var part in parts)
            {
                if (!string.IsNullOrEmpty(part))
                {
                    result += char.ToUpperInvariant(part[0]) + part.Substring(1).ToLowerInvariant();
                }
            }

            return result;
        }
    }
}