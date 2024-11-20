using MSDMarkwort.Kicad.Parser.Base.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection
{
    public class ElementPropertyInfo
    {
        public string ElementName;

        public PropertyInfo PropertyInfo;
    }

    public class ElementParameterInfo
    {
        public int ElementNumber;

        public PropertyInfo PropertyInfo;
    }

    public class TypeCache
    {
        private readonly Dictionary<Type, ElementPropertyInfo[]> _elementPropertyCache = new Dictionary<Type, ElementPropertyInfo[]>();
        private readonly Dictionary<Type, ElementParameterInfo[]> _elementParameterCache = new Dictionary<Type, ElementParameterInfo[]>();

        public void LoadCache(Assembly typeAssembly)
        {
            _elementPropertyCache.Clear();

            foreach (var type in typeAssembly.GetTypes())
            {
                var elementPropertyInfos =
                    type.GetProperties().Where(p =>
                                            p.GetCustomAttribute<KicadElementAttribute>() != null)
                                            .Select(p => new ElementPropertyInfo
                                            {
                                                ElementName = p.GetCustomAttribute<KicadElementAttribute>().ElementName,
                                                PropertyInfo = p
                                            }).ToArray();

                if (elementPropertyInfos.Any())
                {
                    _elementPropertyCache.Add(type, elementPropertyInfos);
                }

                var elementParameterInfos =
                    type.GetProperties().Where(p =>
                            p.GetCustomAttribute<KicadParameterAttribute>() != null)
                        .Select(p => new ElementParameterInfo
                        {
                            ElementNumber = p.GetCustomAttribute<KicadParameterAttribute>().Number,
                            PropertyInfo = p
                        }).ToArray();

                if (elementParameterInfos.Any())
                {
                    _elementParameterCache.Add(type, elementParameterInfos);
                }
            }
        }

        public ElementPropertyInfo GetPropertyInfoByElementName(Type targetType, string attributeName)
        {
            if (!_elementPropertyCache.TryGetValue(targetType, out var typeInfos))
            {
                return null;
            }

            return typeInfos.FirstOrDefault(t => t.ElementName == attributeName);
        }

        public ElementParameterInfo GetPropertyInfoByElementNumber(Type targetType, int number)
        {
            if (!_elementParameterCache.TryGetValue(targetType, out var typeInfos))
            {
                return null;
            }

            return typeInfos.FirstOrDefault(type => type.ElementNumber == number);
        }
    }
}
