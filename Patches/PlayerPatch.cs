using HarmonyLib;
using UnityEngine;

namespace Extrudeous.DragnSprint.Patches
{
    [HarmonyPatch(typeof(WalkingMovementMode))]
    [HarmonyPatch(nameof(WalkingMovementMode.MovementUpdate))]
    class PlayerPatch
    {
        static AccessTools.FieldRef<WalkingMovementMode, float> walkingMovementSpeedRef =
            AccessTools.FieldRefAccess<WalkingMovementMode, float>("walkingMovementSpeed");

        private static float _originalState;
        static bool Prefix(WalkingMovementMode __instance)
        {
            if (!DragnSpringMod.Singleton._sprint.Value)
            {
                if (_originalState != 0f) walkingMovementSpeedRef(__instance) = _originalState;
                _originalState = 0f;
                return true;
            }

            if (_originalState == 0f)
            {
                _originalState = walkingMovementSpeedRef(__instance);
                walkingMovementSpeedRef(__instance) = _originalState * 2;
            }
            
            return true;
        }
    }
}