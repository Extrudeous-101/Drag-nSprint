using HarmonyLib;
using UnityEngine;

namespace Extrudeous.DragnSprint.Patches
{
    using T = WalkingMovementMode;

    [HarmonyPatch(typeof(T))]
    [HarmonyPatch(METHODNAME)]
    class PlayerPatch
    {
        public const string TYPENAME = nameof(WalkingMovementMode);
        public const string METHODNAME = nameof(T.MovementUpdate);
        
        static AccessTools.FieldRef<T, float> walkingMovementSpeedRef =
            AccessTools.FieldRefAccess<T, float>("walkingMovementSpeed");

        private static float _originalState;
        static bool Prefix(T __instance)
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