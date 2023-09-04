using CustomPlayerEffects;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Player;
using Interactables.Interobjects.DoorUtils;
using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace BHOP.Features.Events
{
    public static class Player
    {
        public static void OnJumping(JumpingEventArgs ev)
        {
            var player = ev.Player;

            var current_intensity = player.GetEffectIntensity<MovementBoost>();

            if (current_intensity < 255)
            {
                if (((int)(current_intensity+Plugin.Instance.Config.ExtraSpeedFromJump)) > 255)
                {
                    Utils.SetIntensityMovementBoost(player, 255);

                    return;
                }

                Utils.SetIntensityMovementBoost(player, (byte)(current_intensity + Plugin.Instance.Config.ExtraSpeedFromJump));
            }
        }

        /*

        private static IEnumerator<float> CheckDoorCoroutine(Exiled.API.Features.Player player)
        {
            while (player.IsConnected && player.IsAlive)
            {
                var current_intensity = player.GetEffectIntensity<MovementBoost>();

                RaycastHit hit;

                if (Physics.Raycast(player.CameraTransform.position, player.CameraTransform.forward, out hit, 200f))
                {
                    foreach (Component component in hit.collider.gameObject.GetComponents<DoorVariant>())
                    {
                        Log.Info(component.name);
                    }
                }

                yield return Timing.WaitForOneFrame;
            }
        }
        */
    }
}
