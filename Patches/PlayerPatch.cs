using System;
using BepInEx;
using BepInEx.Configuration;
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
            try
            {
                if (!DragnSpringMod.Singleton.EnableSprint.Value) return true;
                if (!UnityInput.Current.GetKey(DragnSpringMod.Singleton.SprintButton.Value))
                {
                    if (_originalState != 0f) walkingMovementSpeedRef(__instance) = _originalState;
                    _originalState = 0f;
                    return true;
                }

                if (_originalState != 0f) return true;
                
                _originalState = walkingMovementSpeedRef(__instance);
                walkingMovementSpeedRef(__instance) = _originalState * DragnSpringMod.Singleton.SprintSpeed.Value;
            }
            catch (Exception ex)
            {
                DragnSpringMod.ManualLog.LogError($"Patch {typeof(PlayerPatch)} failed to prefix method.");
                DragnSpringMod.ManualLog.LogError(ex);
            }

            return true;
        }
    }
}