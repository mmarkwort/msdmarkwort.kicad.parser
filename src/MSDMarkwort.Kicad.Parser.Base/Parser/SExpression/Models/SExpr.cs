namespace MSDMarkwort.Kicad.Parser.Base.Parser.SExpression.Models
{
    public enum SExprTypes
    {
        List,
        Symbol,
        String
    }

    public abstract class SExpr
    {
        public abstract SExprTypes Type { get; }

        public int LineNumber { get; set; }
    }
}
