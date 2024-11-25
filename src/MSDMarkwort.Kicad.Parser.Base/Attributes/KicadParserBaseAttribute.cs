using System;

namespace MSDMarkwort.Kicad.Parser.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class KicadParserBaseAttribute : Attribute
    {
        public string SymbolName { get; protected set; }

        public bool IsComplex { get; protected set; }

        public KicadParserListAddType ListAddType { get; protected set; }

        public KicadParserSymbolSetType SymbolSetType { get; protected set; }

        public string[] ParameterMappings { get; protected set; }
    }
}
