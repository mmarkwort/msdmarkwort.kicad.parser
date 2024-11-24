namespace MSDMarkwort.Kicad.Parser.Base.Attributes
{
    public class KicadParserSymbolAttribute : KicadParserBaseAttribute
    {
        public KicadParserSymbolAttribute(string symbolName)
        {
            SymbolName = symbolName;
            IsComplex = false;
        }
    }
}
