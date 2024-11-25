namespace MSDMarkwort.Kicad.Parser.Base.Parser.SExpression.Models
{
    public class SExprString : SExpr
    {
        public override SExprTypes Type => SExprTypes.String;

        public string Value { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Value: {Value} (String), Line: {LineNumber}";
        }
    }
}
