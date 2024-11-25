namespace MSDMarkwort.Kicad.Parser.Base.Parser.SExpression.Models
{
    public class SExprSymbol : SExpr
    {
        public override SExprTypes Type => SExprTypes.Symbol;

        public string Value { get; set; }

        public override string ToString()
        {
            return $"Value: {Value} (Symbol), Line: {LineNumber}";
        }

    }
}
