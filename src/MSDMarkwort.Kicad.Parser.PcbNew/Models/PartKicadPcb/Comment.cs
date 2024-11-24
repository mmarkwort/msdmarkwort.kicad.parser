using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb
{
    public class Comment
    {
        [KicadParameter(0)]
        public int Number { get; set; }

        [KicadParameter(1)]
        public string Text { get; set; }
    }
}
