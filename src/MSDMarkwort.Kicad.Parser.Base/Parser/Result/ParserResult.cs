using System;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Result
{
    public class ParserResult<T> where T : class
    {
        public bool Success { get; set; }

        public T Result { get; set; }

        public ParserWarning[] Warnings { get; set; } = Array.Empty<ParserWarning>();

        public ParserError Error { get; set; }
    }
}
