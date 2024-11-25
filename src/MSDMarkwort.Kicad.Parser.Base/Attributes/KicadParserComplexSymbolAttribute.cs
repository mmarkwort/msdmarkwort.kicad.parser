namespace MSDMarkwort.Kicad.Parser.Base.Attributes
{
    public class KicadParserComplexSymbolAttribute : KicadParserSymbolAttribute
    {
        public KicadParserComplexSymbolAttribute(string symbolName) : base(symbolName)
        {
            IsComplex = true;
        }
    }
}
