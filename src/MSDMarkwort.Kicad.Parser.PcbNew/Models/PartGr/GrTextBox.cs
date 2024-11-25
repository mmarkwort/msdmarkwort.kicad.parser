using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartGr
{
    public class GrTextBox : GrBase
    {
        [KicadParameter(0)]
        public string Text { get; set; }

        [KicadParserComplexSymbol("start")]
        public Position StartPosition { get; set; } = new Position();

        [KicadParserComplexSymbol("end")]
        public Position EndPosition { get; set; } = new Position();

        [KicadParserComplexSymbol("margins")]
        public Margin Margin { get; set; } = new Margin();

        [KicadParserComplexSymbol("effects")]
        public Effects Effects { get; set; } = new Effects();

        [KicadParserSymbol("border")]
        public bool HasBorder { get; set; }

        public override string ToString()
        {
            return $"{StartPosition.X}/{StartPosition.Y}-{EndPosition.X}/{EndPosition.Y} ({Layer})";
        }
    }
}
