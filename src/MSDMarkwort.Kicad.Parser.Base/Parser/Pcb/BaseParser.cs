using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using MSDMarkwort.Kicad.Parser.Base.Parser.SExpression;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Pcb
{
    public abstract class BaseParser<T> where T : class
    {
        protected readonly List<ParserWarning> Warnings = new List<ParserWarning>();

        protected BaseParser(TypeCache typeCache)
        {
            TypeCache = typeCache;
        }

        protected TypeCache TypeCache { get; }

        protected virtual Type[] OverrideTypes => Array.Empty<Type>();
        
        protected virtual string[] UnexpectedClosingBracketsIndicators => Array.Empty<string>();

        public ParserResult<T> Parse(string filePath)
        {
            using var fileStream = File.OpenRead(filePath);

            return Parse(fileStream);
        }

        protected abstract bool CheckVersion(T instance);

        public ParserResult<T> Parse(Stream input)
        {
            T instance;
            ParserError error = null;
            Warnings.Clear();

            try
            {
                var expressionParser = new SExpressionParser(input);
                var rootElement = expressionParser.Parse(UnexpectedClosingBracketsIndicators);

                instance = Activator.CreateInstance<T>();
                ApplyElementToModel(instance, rootElement);

                CheckVersion(instance);
            }
            catch (System.Exception e)
            {
                instance = null;
                error = new ParserError { Exception = e };
            }

            return new ParserResult<T>
            {
                Success = error == null,
                Result = instance,
                Warnings = Warnings.ToArray(),
                Error = error
            };
        }

        protected virtual bool HandleOverrideType(Type overrideType, object model, Element element)
        {
            return true;
        }

        protected void ApplyElementToModel(object model, Element element)
        {
            var modelType = model.GetType();

            ApplyParameters(model, element);

            foreach (var childElement in element.Children)
            {
                var warning = ParserWarnings.NoWarning;
                var warningInfo = "";

                var typeInfo = TypeCache.GetPropertyInfoByElementName(modelType, childElement.ElementName);
                if (typeInfo != null)
                {
                    if (OverrideTypes.Contains(typeInfo.PropertyInfo.PropertyType))
                    {
                        HandleOverrideType(typeInfo.PropertyInfo.PropertyType, typeInfo.PropertyInfo.GetValue(model), childElement);
                    }
                    else if (typeInfo.PropertyInfo.PropertyType.IsPrimitive ||
                               typeInfo.PropertyInfo.PropertyType == typeof(string))
                    {
                        warning = model.SetProperty(typeInfo.PropertyInfo,
                            childElement.Parameters.FirstOrDefault() ?? "");
                    }
                    else if (typeInfo.PropertyInfo.PropertyType.IsList())
                    {
                        AddNewListItemToList(typeInfo.PropertyInfo.GetValue(model), childElement);
                    }
                    else
                    {
                        ApplyElementToModel(typeInfo.PropertyInfo.GetValue(model), childElement);
                    }
                }
                else
                {
                    warning = ParserWarnings.ParameterNotFound;
                    warningInfo = childElement.ElementName;
                }

                if (warning != ParserWarnings.NoWarning)
                {
                    Warnings.Add(new ParserWarning
                    {
                        Warning = warning,
                        Information = warningInfo,
                        LineNo = childElement.LineNumber,
                    });
                }
            }
        }

        protected void AddNewListItemToList(object list, Element element)
        {
            var listType = list.GetType();
            var genericType = listType.GetListGenericType();
            var addMethod = listType.GetMethod(nameof(IList.Add));

            object newItem;

            if (genericType == typeof(string))
            {
                newItem = new string(element.Parameters.FirstOrDefault());
            }
            else
            {
                newItem = Activator.CreateInstance(genericType);
            }

            addMethod.Invoke(list, new[] { newItem });

            ApplyElementToModel(newItem, element);
        }

        protected void ApplyParameters(object model, Element element)
        {
            var parameterCounter = 0;

            foreach (var parameter in element.Parameters)
            {
                if (!ApplyParameter(model, parameter, parameterCounter))
                {
                    if (element.Children.Count == 1)
                    {
                        Warnings.Add(new ParserWarning
                        {
                            Warning = ParserWarnings.NoParameterForParameterNumberFound,
                            Information = $"{element.ElementName}: {parameterCounter}",
                            LineNo = element.LineNumber,
                        });
                    }
                }

                ++parameterCounter;
            }
        }

        protected bool ApplyParameter(object model, string value, int number)
        {
            var modelType = model.GetType();

            var typeInfo = TypeCache.GetPropertyInfoByElementNumber(modelType, number);
            if (typeInfo != null)
            {
                model.SetProperty(typeInfo.PropertyInfo, value);
                return true;
            }

            return false;
        }
    }
}
