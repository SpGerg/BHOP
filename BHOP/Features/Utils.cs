using CustomPlayerEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BHOP.Features
{
    public static class Utils
    {
        public static bool IsStaying(Exiled.API.Features.Player player)
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
        
        public static void SetIntensityMovementBoost(Exiled.API.Features.Player player, byte intensity)
        {
            player.ChangeEffectIntensity<MovementBoost>(intensity);
        }
    }
}
