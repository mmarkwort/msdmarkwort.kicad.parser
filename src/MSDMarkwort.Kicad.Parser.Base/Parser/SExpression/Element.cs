using System.Collections.Generic;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.SExpression
{
    public class Element
    {
        public string ElementName { get; set; }

        public Element ParentElement { get; set; }

        public List<Element> Children { get; set; } = new List<Element>();

        public List<string> Parameters { get; set; } = new List<string>();

        public int Level { get; set; }

        public int LineNumber { get; set; }

        public override string ToString()
        {
            return $"{ElementName} (Params: {Parameters.Count}, Level:{Level}, Line: {LineNumber})";
        }
    }
}