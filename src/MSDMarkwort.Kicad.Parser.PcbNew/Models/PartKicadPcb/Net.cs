using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartKicadPcb
{
    public class Net
    {
        [KicadParameter(0)]
        public int Number { get; set; }

        [KicadParameter(1)]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Number}: {Name}";
        }
    }
}
