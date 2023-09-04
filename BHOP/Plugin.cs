using BHOP.Features.Events;
using CustomPlayerEffects;
using Exiled.API.Features;
using Exiled.Events.Handlers;
using InventorySystem.Items.Usables;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Player = BHOP.Features.Events.Player;
using Round = BHOP.Features.Events.Round;
using PlayerHandler = Exiled.Events.Handlers.Player;
using ServerHandler = Exiled.Events.Handlers.Server;

namespace BHOP
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;

            PlayerHandler.Jumping += Player.OnJumping;
            ServerHandler.RoundStarted += Round.OnStarted;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerHandler.Jumping -= Player.OnJumping;
            ServerHandler.RoundStarted -= Round.OnStarted;
        }   
    }
}
