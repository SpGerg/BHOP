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
        public static void OnVerified(VerifiedEventArgs ev)
        {
            var player = ev.Player;
            
            Timing.RunCoroutine(CheckSpeedCoroutine(player));

            //if (Plugin.Instance.Config.IsDoorBreaking)
            //{
                //Timing.RunCoroutine(CheckDoorCoroutine(player));
            //}
        }

        public static void OnJumping(JumpingEventArgs ev)
        {
            var player = ev.Player;

            var current_intensity = player.GetEffectIntensity<MovementBoost>();

            if (current_intensity < 255)
            {
                if (((int)(current_intensity+Plugin.Instance.Config.ExtraSpeedFromJump)) > 255)
                {
                    SetIntensityMovementBoost(player, 255);

                    return;
                }

                SetIntensityMovementBoost(player, (byte)(current_intensity + Plugin.Instance.Config.ExtraSpeedFromJump));
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

        private static IEnumerator<float> CheckSpeedCoroutine(Exiled.API.Features.Player player)
        {
            while (player.IsConnected)
            {
                if (!player.IsEffectActive<MovementBoost>())
                {
                    player.EnableEffect<MovementBoost>();
                }

                var current_intensity = player.GetEffectIntensity<MovementBoost>();

                if (IsStaying(player))
                {
                    SetIntensityMovementBoost(player, 0);
                }
                else
                {
                    if (current_intensity > 5)
                    {
                        SetIntensityMovementBoost(player, (byte)(current_intensity - Plugin.Instance.Config.ReducedSpeedOnStop));
                    }
                    else
                    {
                        SetIntensityMovementBoost(player, 0);
                    }
                }

                yield return Timing.WaitForSeconds(0.1f);
            }
        }

        private static bool IsStaying(Exiled.API.Features.Player player)
        {
            if (player.Velocity.x != Vector3.zero.x)
            {
                return false;
            }
            else if (player.Velocity.y != Vector3.zero.y)
            {
                return false;
            }
            else if (player.Velocity.z != Vector3.zero.z)
            {
                return false;
            }

            return true;
        }

        private static void SetIntensityMovementBoost(Exiled.API.Features.Player player, byte intensity)
        {
            player.ChangeEffectIntensity<MovementBoost>(intensity);
        }
    }
}
