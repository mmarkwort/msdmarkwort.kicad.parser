namespace MSDMarkwort.Kicad.Parser.Base.Parser.Exception
{
    public class ParserException : System.Exception
    {
        public ParserException(int lineNumber, System.Exception innerException)
            : base("Fatal parsing error. See inner exceptions for details.", innerException)
        {
            LineNumber = lineNumber;
        }

        public int LineNumber { get; }
    }
}
