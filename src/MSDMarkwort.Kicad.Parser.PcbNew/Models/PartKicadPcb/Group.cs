using System;
using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb
{
    public class Group
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadElement("uuid")]
        public Guid Uuid { get; set; }

        [KicadElement("members")]
        public List<string> Members { get; set; } = new List<string>(); // ToDo: Not all members are parsed
    }
}
