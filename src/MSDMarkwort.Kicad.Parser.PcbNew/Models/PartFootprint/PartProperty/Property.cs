using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartProperty
{
    public class Property
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParameter(1)]
        public string Value { get; set; }

        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserSymbol("tstamp")]
        public Guid TStamp { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadParserSymbol("layer")]
        public string Layer { get; set; }

        [KicadParserSymbol("hide")]
        public bool Hide { get; set; }

        [KicadParserSymbol("unlocked")]
        public bool Unlocked { get; set; }

        [KicadParserComplexSymbol("effects")]
        public Effects Effects { get; set; } = new Effects();

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}
