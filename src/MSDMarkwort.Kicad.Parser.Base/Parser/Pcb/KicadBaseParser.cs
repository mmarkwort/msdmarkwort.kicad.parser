using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using MSDMarkwort.Kicad.Parser.Base.Parser.SExpression;
using MSDMarkwort.Kicad.Parser.Base.Parser.SExpression.Models;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Pcb
{
    public abstract class KicadRootModel<T> where T : class
    {
        public abstract T Root { get; set; }
    }

    public abstract class KicadBaseParser<TModel, TRootModel> where TModel : class where TRootModel : KicadRootModel<TModel>
    {
        protected readonly List<ParserWarning> Warnings = new List<ParserWarning>();

        protected KicadBaseParser(TypeCache typeCache)
        {
            TypeCache = typeCache;
        }

        protected TypeCache TypeCache { get; }

        protected virtual Type[] OverrideTypes => Array.Empty<Type>();
        
        protected virtual string[] UnexpectedClosingBracketsIndicators => Array.Empty<string>();

        public ParserResult<TModel> Parse(string filePath)
        {
            using var fileStream = File.OpenRead(filePath);

            return Parse(fileStream);
        }

        protected abstract bool CheckVersion(TModel instance);

        public ParserResult<TModel> Parse(Stream input)
        {
            TRootModel instance;
            var expressionParser = new SExpressionParser();
            ParserError error = null;
            
            Warnings.Clear();

            try
            {
                var rootElement = expressionParser.ParseStream(input);

                instance = Activator.CreateInstance<TRootModel>();
                ApplyListToModel(instance, (SExprList)rootElement);

                CheckVersion(instance.Root);
            }
            catch (System.Exception e)
            {
                instance = null;
                error = new ParserError { Exception = e };
            }

            return new ParserResult<TModel>
            {
                Success = error == null,
                Result = instance?.Root,
                Warnings = Warnings.ToArray(),
                Error = error
            };
        }

        protected virtual int HandleOverrideType(Type overrideType, object model, List<SExpr> containingList, int idxInList, SExprSymbol symbol, out object overrideModel, out Type overrideModelType)
        {
            overrideModel = null;
            overrideModelType = null;

            return int.MinValue;
        }

        protected void ApplyListToModel(object model, SExprList list)
        {
            ApplyListToModel(model, list.Children);
        }

        protected void ApplyListToModel(object model, List<SExpr> list)
        {
            var idx = 0;
            var modelType = model.GetType();
            var tempStringList = new List<string>();
            SymbolPropertyInfo currentSymbolPropertyInfo = null;
            var parameterCounter = 0;

            for (; idx < list.Count; ++idx)
            {
                var expr = list[idx];

                switch (expr.Type)
                {
                    case SExprTypes.List:
                        var l = (SExprList)expr;
                        parameterCounter = 0;
                        currentSymbolPropertyInfo = null;

                        ApplyListToModel(model, l);
                        break;
                    case SExprTypes.Symbol:
                    {
                        var symbol = (SExprSymbol)expr;
                        parameterCounter = 0;

                        var overrideIdx = HandleOverrideType(modelType, model, list, idx, symbol, out var overrideModel, out var overrideType);
                        if (overrideIdx != int.MinValue)
                        {
                            model = overrideModel;
                            modelType = overrideType;
                            idx = overrideIdx;

                            currentSymbolPropertyInfo = TypeCache.GetPropertyInfoBySymbolName(overrideType, symbol.Value);
                            continue;
                        }

                        var typeInfo = TypeCache.GetPropertyInfoBySymbolName(modelType, symbol.Value);
                        if (typeInfo != null)
                        {
                            if (typeInfo.ListAddType != KicadParserListAddType.NotSet)
                            {
                                switch (typeInfo.ListAddType)
                                {
                                    case KicadParserListAddType.Complex:
                                        var targetList = typeInfo.PropertyInfo.GetValue(model);
                                        var addedItem = AddSymbolToList(targetList);

                                        modelType = addedItem.GetType();
                                        model = addedItem;

                                        currentSymbolPropertyInfo = typeInfo;
                                        break;
                                    case KicadParserListAddType.FromParameters:
                                        currentSymbolPropertyInfo = typeInfo;
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }

                                continue;
                            }

                            if (typeInfo.SymbolSetType == KicadParserSymbolSetType.ImplicitBoolTrue)
                            {
                                if (typeInfo.PropertyInfo.PropertyType != typeof(bool))
                                {
                                    Warnings.Add(new ParserWarning
                                    {
                                        Warning = ParserWarnings.ImplicitSymbolUnsupportedPropertyType,
                                        Information = $"Setting of an implicit marked symbol can only be applied to boolean property. Property {typeInfo.PropertyInfo.Name}, Symbol {symbol.Value}",
                                        LineNo = symbol.LineNumber
                                    });
                                    
                                    continue;
                                }

                                typeInfo.PropertyInfo.SetValue(model, true);
                                continue;
                            }

                            if (typeInfo.IsComplex)
                            {
                                modelType = typeInfo.PropertyInfo.PropertyType;
                                model = typeInfo.PropertyInfo.GetValue(model);
                            }

                            currentSymbolPropertyInfo = typeInfo;
                        }
                        else
                        {
                            // Add warning here
                            Warnings.Add(new ParserWarning
                            {
                                Warning = ParserWarnings.SymbolNotFound,
                                Information = $"No setter found for symbol {symbol.Value} in type {modelType.Name}",
                                LineNo = symbol.LineNumber
                            });
                        }
                        break;
                    }
                    case SExprTypes.String:
                    {
                        var strExpr = (SExprString)expr;

                        if (currentSymbolPropertyInfo != null)
                        {
                            if (currentSymbolPropertyInfo.ListAddType == KicadParserListAddType.FromParameters)
                            {
                                var parameterList = currentSymbolPropertyInfo.PropertyInfo.GetValue(model);
                                AddParameterToList(parameterList, strExpr);
                                continue;
                            }

                            if (currentSymbolPropertyInfo.SymbolSetType == KicadParserSymbolSetType.TreatParametersAsOneString)
                            {
                                tempStringList.Add(strExpr.Value);

                                if (list.Count - 1 == idx ||
                                   list[idx + 1].Type != SExprTypes.String)
                                {
                                    ApplyParameterToModel(model, currentSymbolPropertyInfo, new SExprString
                                    {
                                        Value = string.Concat(tempStringList)
                                    });
                                }

                                continue;
                            }

                            if (!currentSymbolPropertyInfo.IsComplex)
                            {
                                ApplyParameterToModel(model, currentSymbolPropertyInfo, strExpr);
                                continue;
                            }
                        }

                        var typeInfo = TypeCache.GetPropertyInfoByParameterNumber(model.GetType(), parameterCounter);
                        if (typeInfo != null)
                        {
                            ApplyParameterToModel(model, typeInfo, strExpr);
                        }
                        else
                        {
                            var propertyInfo = TypeCache.GetPropertyInfoByParameterMapping(model.GetType(), strExpr.Value);
                            if (propertyInfo != null)
                            {
                                ApplyParameterToModel(model, propertyInfo, strExpr);
                            }
                            else
                            {
                                Warnings.Add(new ParserWarning
                                {
                                    Warning = ParserWarnings.NoParameterForParameterNumberFound,
                                    Information = $"Parameter {parameterCounter} not found in {model.GetType().Name}. Value: {strExpr.Value}",
                                    LineNo = strExpr.LineNumber
                                });
                            }
                        }
                        
                        ++parameterCounter;
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected void ApplyParameterToModel(object model, SymbolParameterInfo parameterInfo, SExprString sexprString)
        {
            model.SetProperty(parameterInfo.PropertyInfo, sexprString.Value);
        }

        protected void ApplyParameterToModel(object model, SymbolPropertyInfo propertyInfo, SExprString sexprString)
        {
            model.SetProperty(propertyInfo.PropertyInfo, sexprString.Value);
        }

        protected object AddSymbolToList(object list)
        {
            var listType = list.GetType();
            var genericType = listType.GetListGenericType();

            var newItem = Activator.CreateInstance(genericType);

            var addMethod = listType.GetMethod(nameof(IList.Add));
            addMethod.Invoke(list, new[] { newItem });

            return newItem;
        }

        protected void AddParameterToList(object list, SExprString sexprString)
        {
            var listType = list.GetType();
            var genericType = listType.GetListGenericType();

            if (genericType != typeof(string) && genericType != typeof(Guid))
            {
                Warnings.Add(new ParserWarning
                {
                    Warning = ParserWarnings.ListTypeNotSupported,
                    Information = $"{sexprString.Value} cannot be added because list type is {genericType.Name}",
                    LineNo = sexprString.LineNumber
                });

                return;
            }

            object newItem = null;

            if (genericType == typeof(string))
            {
                newItem = new string(sexprString.Value);
            }
            else if (genericType == typeof(Guid))
            {
                newItem = Guid.Parse(sexprString.Value);
            }

            var addMethod = listType.GetMethod(nameof(IList.Add));
            addMethod.Invoke(list, new[] { newItem });
        }
    }
}