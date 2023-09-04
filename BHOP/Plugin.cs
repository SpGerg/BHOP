using BHOP.Features.Events;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Player = BHOP.Features.Events.Player;
using PlayerHandler = Exiled.Events.Handlers.Player;

namespace BHOP
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;

            PlayerHandler.Verified += Player.OnVerified;
            PlayerHandler.Jumping += Player.OnJumping;

            base.OnEnabled();
        }
    }
}
