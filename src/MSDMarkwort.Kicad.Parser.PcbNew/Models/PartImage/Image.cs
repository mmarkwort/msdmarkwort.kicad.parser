using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartImage
{
    public class Image
    {
        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserSymbol("locked")]
        public bool IsLocked { get; set; }

        [KicadParserSymbol("scale")]
        public double Scale { get; set; }

        [KicadParserSymbol("layer")]
        public string Layer { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadParserSymbol("data", KicadParserSymbolSetType.TreatParametersAsOneString)]
        public byte[] Data { get; set; }
    }
}
