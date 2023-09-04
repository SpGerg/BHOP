using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHOP
{
    public class Config : IConfig
    {
        [Description("Is enabled or not")]
        public bool IsEnabled { get; set; }

        [Description("Is debug or not")]
        public bool Debug { get; set; }

        /*
        [Description("Is door breaking")]
        public bool IsDoorBreaking { get; set; }
        */

        /*
        [Description("After what speed threshold will the player break doors")]
        public byte DoorBreakingSpeed { get; set; }
        */

        [Description("Max speed (in game is 255)")]
        public float MaxSpeed { get; set; } = 255;

        [Description("Extra speed from jump")]
        public float ExtraSpeedFromJump { get; set; } = 15;

        [Description("Reduced speed while standing still (every second)")]
        public byte ReducedSpeedOnStop { get; set; } = 5;
    }
}
