using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class RenderCache
    {
        [KicadParameter(0)]
        public string Text { get; set; }

        [KicadParameter(1)]
        public string Angle { get; set; }

        [KicadParserList("polygon", KicadParserListAddType.Complex)]
        public PolygonCollection Polygons { get; set; } = new PolygonCollection();
    }
}
