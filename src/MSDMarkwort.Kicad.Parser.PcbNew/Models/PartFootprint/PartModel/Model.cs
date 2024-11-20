using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartModel
{
    public class Model
    {
        [KicadElement("hide")]
        public bool Hide { get; set; }

        [KicadElement("offset")]
        public PositionXYZProxy Offset { get; set; } = new PositionXYZProxy();

        [KicadElement("scale")]
        public PositionXYZProxy Scale { get; set; } = new PositionXYZProxy();

        [KicadElement("rotate")]
        public PositionXYZProxy Rotate { get; set; } = new PositionXYZProxy();
    }
}
