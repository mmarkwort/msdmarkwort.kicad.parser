namespace MSDMarkwort.Kicad.Parser.Base.Attributes
{
    public class KicadParserSymbolAttribute : KicadParserBaseAttribute
    {
        public KicadParserSymbolAttribute(string symbolName, KicadParserSymbolSetType symbolSetType = KicadParserSymbolSetType.SetParameter, params string[] parameterMappings)
        {
            SymbolName = symbolName;
            SymbolSetType = symbolSetType;
            IsComplex = false;
            ParameterMappings = parameterMappings;
        }
    }
}
