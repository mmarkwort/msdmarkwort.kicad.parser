using System;

namespace MSDMarkwort.Kicad.Parser.Base.Attributes
{
    public class KicadParserListAttribute : KicadParserSymbolAttribute
    {
        public KicadParserListAttribute(string symbolName, KicadParserListAddType listAddType) : base(symbolName)
        {
            ListAddType = listAddType;

            switch (listAddType)
            {
                case KicadParserListAddType.Complex:
                    IsComplex = true;
                    break;
                case KicadParserListAddType.NotSet:
                case KicadParserListAddType.FromParameters:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(listAddType), listAddType, null);
            }
        }
    }
}
