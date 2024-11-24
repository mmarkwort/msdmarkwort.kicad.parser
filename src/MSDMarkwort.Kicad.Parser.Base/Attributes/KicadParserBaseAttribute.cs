using System;

namespace MSDMarkwort.Kicad.Parser.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KicadParserBaseAttribute : Attribute
    {
        public string SymbolName { get; protected set; }

        public bool IsComplex { get; protected set; }

        public KicadParserListAddType AddType { get; protected set; }
    }
}
