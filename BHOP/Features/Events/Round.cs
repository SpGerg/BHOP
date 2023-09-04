using CustomPlayerEffects;
using MEC;
using System.Collections.Generic;

namespace BHOP.Features.Events
{
    public static class Round
    {
        public static void OnStarted()
        {
            Timing.RunCoroutine(CheckSpeedCoroutine());
        }

        private static IEnumerator<float> CheckSpeedCoroutine()
        {
            foreach (var player in Exiled.API.Features.Player.List)
            {
                while (player.IsConnected)
                {
                    if (!player.IsEffectActive<MovementBoost>())
                    {
                        player.EnableEffect<MovementBoost>();
                    }

                    var current_intensity = player.GetEffectIntensity<MovementBoost>();

                    if (Utils.IsStaying(player))
                    {
                        Utils.SetIntensityMovementBoost(player, 0);
                    }
                    else
                    {
                        if (current_intensity > 5)
                        {
                            Utils.SetIntensityMovementBoost(player, (byte)(current_intensity - Plugin.Instance.Config.ReducedSpeedOnStop));
                        }
                        else
                        {
                            Utils.SetIntensityMovementBoost(player, 0);
                        }
                    }

                    yield return Timing.WaitForSeconds(0.1f);
                }
            }
        }
    }
}
