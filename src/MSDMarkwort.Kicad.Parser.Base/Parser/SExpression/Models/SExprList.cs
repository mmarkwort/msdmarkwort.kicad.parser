using System.Collections.Generic;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.SExpression.Models
{
    public class SExprList : SExpr
    {
        public override SExprTypes Type => SExprTypes.List;

        public List<SExpr> Children { get; set; } = new List<SExpr>();

        public override string ToString()
        {
            return $"Children: {Children.Count}, Line: {LineNumber}";
        }
    }
}
