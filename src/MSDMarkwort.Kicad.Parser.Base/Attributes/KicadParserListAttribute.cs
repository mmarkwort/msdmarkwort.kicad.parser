using System;

namespace MSDMarkwort.Kicad.Parser.Base.Attributes
{
    public class KicadParserListAttribute : KicadParserSymbolAttribute
    {
        public KicadParserListAttribute(string symbolName, KicadParserListAddType addType) : base(symbolName)
        {
            AddType = addType;

            switch (addType)
            {
                case KicadParserListAddType.Complex:
                    IsComplex = true;
                    break;
                case KicadParserListAddType.NotSet:
                case KicadParserListAddType.FromParameters:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(addType), addType, null);
            }
        }
    }
}
