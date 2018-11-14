using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Simulation
{
    public enum WindDirection
    {
        [Description("NORTH")]
        NORTH,
        [Description("NORTH-EAST")]
        NORTHEAST,
        [Description("NORTH-WEST")]
        NORTHWEST,
        [Description("SOUTH")]
        SOUTH,
        [Description("SOUTH-EAST")]
        SOUTHEAST,
        [Description("SOUTH-WEST")]
        SOUTHWEST,
        [Description("EAST")]
        EAST,
        [Description("WEST")]
        WEST
    }
}
