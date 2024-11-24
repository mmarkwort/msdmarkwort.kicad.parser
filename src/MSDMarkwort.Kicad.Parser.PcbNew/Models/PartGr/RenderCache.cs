using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class RenderCache
    {
        [KicadParameter(0)]
        public string Text { get; set; }

        [KicadParserSymbol("polygon")]
        public PolygonCollection Polygons { get; set; } = new PolygonCollection();
    }
}
