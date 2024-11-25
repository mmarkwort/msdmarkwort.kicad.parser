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
        [KicadParserSymbol("id")]
        public Guid Uuid { get; set; }

        [KicadParserSymbol("locked", parameterMappings: "locked")]
        public bool IsLocked { get; set; }

        [KicadParserList("members", KicadParserListAddType.FromParameters)]
        public List<Guid> Members { get; set; } = new List<Guid>();
    }
}
