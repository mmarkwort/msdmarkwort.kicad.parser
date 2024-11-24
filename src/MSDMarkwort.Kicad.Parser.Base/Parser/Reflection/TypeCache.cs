using MSDMarkwort.Kicad.Parser.Base.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Reflection
{
    public class SymbolPropertyInfo
    {
        public string SymbolName;

        public bool IsComplex;

        public KicadParserListAddType AddType;

        public PropertyInfo PropertyInfo;
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

        public void LoadCache(Assembly typeAssembly)
        {
            _symbolPropertyCache.Clear();

            foreach (var type in typeAssembly.GetTypes())
            {
                var symbolPropertyInfos =
                    type.GetProperties().Where(p => p.GetCustomAttribute<KicadParserBaseAttribute>() != null)
                                            .Select(p =>
                                            {
                                                var attr = p.GetCustomAttribute<KicadParserBaseAttribute>();
                                                if (attr == null)
                                                {
                                                    throw new InvalidOperationException("Attribute not expected");
                                                }

                                                return new SymbolPropertyInfo
                                                {
                                                    SymbolName = attr.SymbolName,
                                                    IsComplex = attr.IsComplex,
                                                    AddType = attr.AddType,
                                                    PropertyInfo = p
                                                };
                                            }).ToArray();

                if (symbolPropertyInfos.Any())
                {
                    _symbolPropertyCache.Add(type, symbolPropertyInfos);
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
