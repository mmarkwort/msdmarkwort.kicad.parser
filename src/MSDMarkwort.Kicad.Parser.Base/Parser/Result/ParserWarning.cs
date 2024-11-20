namespace MSDMarkwort.Kicad.Parser.Base.Parser.Result
{
    public class ParserWarning
    {
        public int LineNo { get; set; }

        public ParserWarnings Warning { get; set; }

        public string Information { get; set; }

        public override string ToString()
        {
            return $"In line {LineNo}: {Warning}: {Information}";
        }
    }
}
