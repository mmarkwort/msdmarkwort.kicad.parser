using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection
{
    public class SymbolPropertyInfo
    {
        public string SymbolName;

        public bool IsComplex;

        public KicadParserListAddType ListAddType;

        public KicadParserSymbolSetType SymbolSetType;

        public PropertyInfo PropertyInfo;

        public string[] ParameterMappings;
    }

    public class SymbolParameterInfo
    {
        public int ParameterNumber;

        public PropertyInfo PropertyInfo;
    }

    public class TypeCache
    {
        private readonly Dictionary<Type, SymbolPropertyInfo[]> _symbolPropertyCache = new Dictionary<Type, SymbolPropertyInfo[]>();
        private readonly Dictionary<Type, SymbolParameterInfo[]> _symbolParameterCache = new Dictionary<Type, SymbolParameterInfo[]>();

        public void LoadCache(Assembly[] typeAssemblies)
        {
            _symbolPropertyCache.Clear();

            foreach (var type in typeAssemblies.SelectMany(a => a.GetTypes()))
            {
                var symbolPropertyInfos = new List<SymbolPropertyInfo>();
                foreach (var property in type.GetProperties())
                {
                    symbolPropertyInfos.AddRange(property.GetCustomAttributes<KicadParserBaseAttribute>()
                        .Select(attribute => new SymbolPropertyInfo
                        {
                            SymbolName = attribute.SymbolName,
                            IsComplex = attribute.IsComplex,
                            ListAddType = attribute.ListAddType,
                            SymbolSetType = attribute.SymbolSetType,
                            PropertyInfo = property,
                            ParameterMappings = attribute.ParameterMappings
                        }));
                }

                if (symbolPropertyInfos.Any())
                {
                    _symbolPropertyCache.Add(type, symbolPropertyInfos.ToArray());
                }

                var symbolParameterInfos =
                    type.GetProperties().Where(p =>
                            p.GetCustomAttribute<KicadParameterAttribute>() != null)
                        .Select(p =>
                        {
                            var attr = p.GetCustomAttribute<KicadParameterAttribute>();
                            if (attr == null)
                            {
                                throw new InvalidOperationException("Attribute not expected");
                            }

                            return new SymbolParameterInfo
                            {
                                ParameterNumber = attr.Number,
                                PropertyInfo = p
                            };
                        }).ToArray();

                if (symbolParameterInfos.Any())
                {
                    _symbolParameterCache.Add(type, symbolParameterInfos);
                }
            }
        }

        public SymbolPropertyInfo GetPropertyInfoBySymbolName(Type targetType, string symbolName)
        {
            if (!_symbolPropertyCache.TryGetValue(targetType, out var typeInfos))
            {
                return null;
            }

            return typeInfos.FirstOrDefault(t => t.SymbolName == symbolName);
        }

        public SymbolPropertyInfo GetPropertyInfoByParameterMapping(Type targetType, string value)
        {
            if (!_symbolPropertyCache.TryGetValue(targetType, out var typeInfos))
            {
                return null;
            }

            return typeInfos.FirstOrDefault(t => t.ParameterMappings.Contains(value));
        }

        public SymbolParameterInfo GetPropertyInfoByParameterNumber(Type targetType, int parameterNumber)
        {
            if (!_symbolParameterCache.TryGetValue(targetType, out var typeInfos))
            {
                return null;
            }

            return typeInfos.FirstOrDefault(type => type.ParameterNumber == parameterNumber);
        }
    }
}
