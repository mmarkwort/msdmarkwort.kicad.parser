using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb
{
    public class Group
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserList("members", KicadParserListAddType.FromParameters)]
        public List<string> Members { get; set; } = new List<string>();
    }
}
