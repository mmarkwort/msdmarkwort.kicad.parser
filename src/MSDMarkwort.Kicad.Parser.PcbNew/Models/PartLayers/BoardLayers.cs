using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartLayers
{
    public class BoardLayers
    {
        [KicadParserList("layers", KicadParserListAddType.Complex)]
        public BoardLayerCollection Layers { get; set; } = new BoardLayerCollection();
    }
}
