using MSDMarkwort.Kicad.Parser.Base.Parser.Pcb;
using MSDMarkwort.Kicad.Parser.Base.Parser.Reflection;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using MSDMarkwort.Kicad.Parser.Base.Parser.SExpression;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartPad;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartLayers;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.PartSetup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MSDMarkwort.Kicad.Parser.PcbNew
{
    public class PcbNewParser : BaseParser<KicadPcb>
    {
        private static readonly TypeCache StaticTypeCache = new TypeCache();

        protected ReadOnlyCollection<int> SupportedVersions = new ReadOnlyCollection<int>(new List<int>()
        {
            20231014,
            20231212,
            20231231,
            20240108
        });

        static PcbNewParser()
        {
            StaticTypeCache.LoadCache(typeof(PcbNewParser).Assembly);
        }

        public PcbNewParser() : base(StaticTypeCache)
        {
        }

        protected override Type[] OverrideTypes => new[] { typeof(BoardLayerCollection), typeof(Drill), typeof(Tenting) };

        protected override bool CheckVersion(KicadPcb instance)
        {
            if (instance.Version < SupportedVersions[0])
            {
                Warnings.Add(new ParserWarning
                {
                    Warning = ParserWarnings.MaybeUnsupportedFileVersion,
                    Information = $"Version could not be supported: {instance.Version}",
                    LineNo = 0
                });

                return false;
            }

            return true;
        }

        protected override bool HandleOverrideType(Type overrideType, object model, Element element)
        {
            if (model.GetType() == typeof(BoardLayerCollection))
            {
                HandleBoardLayerCollection(model as BoardLayerCollection, element.Children);
            }
            else if (model.GetType() == typeof(Drill))
            {
                HandleDrill(model as Drill, element);
            }
            else if (model.GetType() == typeof(Tenting))
            {
                HandleTenting(model as Tenting, element);
            }

            return true;
        }

        private void HandleBoardLayerCollection(BoardLayerCollection boardLayerCollection, List<Element> layerElements)
        {
            foreach (var layerElement in layerElements)
            {
                var newLayer = new BoardLayer();
                boardLayerCollection.Add(newLayer);

                if (int.TryParse(layerElement.ElementName, out var number))
                {
                    newLayer.Number = number;
                }
                else
                {
                    Warnings.Add(new ParserWarning
                    {
                        Warning = ParserWarnings.ParameterSetFailed,
                        Information = $"{layerElement.ElementName}",
                        LineNo = layerElement.LineNumber
                    });
                }

                var parameterCounter = 1;
                foreach (var parameter in layerElement.Parameters)
                {
                    ApplyParameter(newLayer, parameter, parameterCounter);
                    ++parameterCounter;
                }
            }
        }

        private void HandleDrill(Drill drill, Element element)
        {
            if (element.Parameters.Count == 1)
            {
                if (double.TryParse(element.Parameters[0], out var outerDiameter))
                {
                    drill.OuterDiameter = outerDiameter;
                }
                else
                {
                    Warnings.Add(new ParserWarning
                    {
                        Warning = ParserWarnings.ParameterSetFailed,
                        Information = $"{element.ElementName}",
                        LineNo = element.LineNumber
                    });
                }
            }
            else if (element.Parameters.Count > 1)
            {
                ApplyParameters(drill, element);
            }
        }

        private void HandleTenting(Tenting tenting, Element element)
        {
            foreach (var parameter in element.Parameters)
            {
                if (parameter == "front")
                {
                    tenting.TentViaFront = true;
                }
                else if (parameter == "back")
                {
                    tenting.TentViaBack = true;
                }
                else
                {
                    Warnings.Add(new ParserWarning
                    {
                        Warning = ParserWarnings.ParameterNotFound,
                        Information = $"{element.ElementName}: Unknown parameters: {string.Join(',', element.Parameters)}",
                        LineNo = element.LineNumber
                    });
                }
            }
        }
    }
}
