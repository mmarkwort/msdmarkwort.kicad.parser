using System;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.Result
{
    public class ParserResult<T> where T : class
    {
        public bool Success { get; internal set; }

        public T Result { get; internal set; }

        public ParserWarning[] Warnings { get; internal set; } = Array.Empty<ParserWarning>();

        public ParserError Error { get; internal set; }
    }
}
