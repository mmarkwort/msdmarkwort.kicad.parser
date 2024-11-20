﻿using MSDMarkwort.Kicad.Parser.Base.Attributes;

namespace MSDMarkwort.Kicad.Parser.PcbNew.Models.Common
{
    public class PositionAt : Position
    {
        [KicadParameter(2)]
        public double Angle { get; set; }

        public override string ToString()
        {
            return $"{X}/{Y} ({Angle}°)";
        }
    }
}
