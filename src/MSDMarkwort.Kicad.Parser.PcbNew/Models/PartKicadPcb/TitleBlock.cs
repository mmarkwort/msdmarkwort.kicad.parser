using System.Collections.Generic;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb
{
    public class TitleBlock
    {
        [KicadElement("title")]
        public string Title { get; set; }

        [KicadElement("date")]
        public string Date { get; set; }

        [KicadElement("rev")]
        public string Revision { get; set; }

        [KicadElement("company")]
        public string Company { get; set; }

        [KicadElement("comment")]
        public List<string> Comments { get; set; } = new List<string>();
    }
}
