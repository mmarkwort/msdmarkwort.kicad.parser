using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class TitleBlock
    {
        [KicadParserSymbol("title")]
        public string Title { get; set; }

        [KicadParserSymbol("date")]
        public string Date { get; set; }

        [KicadParserSymbol("rev")]
        public string Revision { get; set; }

        [KicadParserSymbol("company")]
        public string Company { get; set; }

        [KicadParserList("comment", KicadParserListAddType.Complex)]
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
