using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common.Enums;

namespace MSDMarkwort.Kicad.Parser.Model.Common
{
    public class Justify
    {
        [KicadParameter(0)]
        public HorizontalAlignment HorizontalAlignment { get; set; }

        [KicadParameter(1)]
        public VerticalAlignment VerticalAlignment { get; set; }

        [KicadParameter(2)]
        public JustifyMirror Mirror { get; set; }
    }
}
