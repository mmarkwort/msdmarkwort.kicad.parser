using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartLayers
{
    public class BoardLayer
    {
        [KicadParameter(0)]
        public int Number { get; set; }

        [KicadParameter(1)]
        public string ShortName { get; set; }

        [KicadParameter(2)]
        public string LayerType { get; set; }

        [KicadParameter(3)]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{ShortName} -> {LayerType} ({Name})";
        }
    }
}
