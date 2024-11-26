using System;
using MSDMarkwort.Kicad.Parser.Base.Attributes;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartInstances;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartPin;
using MSDMarkwort.Kicad.Parser.EESchema.Models.PartSymbol.PartProperty;
using MSDMarkwort.Kicad.Parser.Model.Common;

namespace MSDMarkwort.Kicad.Parser.EESchema.Models.PartSheet
{
    public class Sheet
    {
        [KicadParserSymbol("uuid")]
        public Guid Uuid { get; set; }

        [KicadParserComplexSymbol("at")]
        public PositionAt At { get; set; } = new PositionAt();

        [KicadParserComplexSymbol("size")]
        public Size Size { get; set; } = new Size();

        [KicadParserSymbol("exclude_from_sim")]
        public bool ExcludeFromSim { get; set; }

        [KicadParserSymbol("in_bom")]
        public bool InBom { get; set; }

        [KicadParserSymbol("on_board")]
        public bool OnBoard { get; set; }

        [KicadParserSymbol("dnp")]
        public bool Dnp { get; set; }

        [KicadParserSymbol("fields_autoplaced")]
        public bool FieldsAutoplaced { get; set; }

        [KicadParserComplexSymbol("stroke")]
        public Stroke Stroke { get; set; } = new Stroke();

        [KicadParserComplexSymbol("fill")]
        public Fill Fill { get; set; } = new Fill();

        [KicadParserList("property", KicadParserListAddType.Complex)]
        public PropertyCollection Properties { get; set; } = new PropertyCollection();

        [KicadParserList("pin", KicadParserListAddType.Complex)]
        public PinCollection Pins { get; set; } = new PinCollection();

        [KicadParserList("instances", KicadParserListAddType.Complex)]
        public InstanceCollection Instances { get; set; } = new InstanceCollection();
    }
}
