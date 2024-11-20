using MSDMarkwort.Kicad.Parser.PcbNew.Models.Common;
using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.PartFootprint.PartProperty
{
    public class Property
    {
        [KicadParameter(0)]
        public string Name { get; set; }

        [KicadParameter(1)]
        public string Value { get; set; }

        [KicadElement("uuid")]
        public Guid Uuid { get; set; }

        [KicadElement("at")]
        public PositionAt PositionAt { get; set; } = new PositionAt();

        [KicadElement("layer")]
        public string Layer { get; set; }

        [KicadElement("hide")]
        public bool Hide { get; set; }

        [KicadElement("unlocked")]
        public bool Unlocked { get; set; }

        [KicadElement("effects")]
        public Effects Effects { get; set; } = new Effects();

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}
