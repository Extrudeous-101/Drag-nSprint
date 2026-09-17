using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using DragNWash.ModFramework;
using Extrudeous.DragnSprint.Patches;
using HarmonyLib;
using UnityEngine;

namespace Extrudeous.DragnSprint
{
    [BepInPlugin(GUID, MOD_NAME, "1.0")]
    [BepInDependency(ModFramework.Guid, BepInDependency.DependencyFlags.HardDependency)]
    public class DragnSpringMod : BaseUnityPlugin
    {
        public static DragnSpringMod Singleton;
        public static ManualLogSource ManualLog;
        
        public const string GUID = "extrudeous.dragnsprint";
        public const string MOD_NAME = "Drag'n Sprint";
        public const string MOD_DESCRIPTION = "Adds sprint to the player.";
        public const string MOD_WEBSITE = "https://github.com/Extrudeous-101/DragnSprint";
        public static readonly string[] MOD_AUTHORS = new[] { "Extrudeous" };

        private const string SPRINTING_PATCH = "Sprinting";
    
        public ConfigEntry<bool> _sprint;
        public ConfigEntry<float> SprintSpeed;
    
        private void Awake()
        {
            Singleton = !Singleton ? this : Singleton;
            ManualLog = Logger;
            
            ModFramework.Register(new ModInfo
            {
                Guid = GUID,
                DisplayName = MOD_NAME,
                Description = MOD_DESCRIPTION,
                Authors = MOD_AUTHORS,
                Website = MOD_WEBSITE
            });
            Logger.LogDebug("Registered mod.");
            
            _sprint = Config.Bind("General", "Make me sprint", false, "Makes you sprint 🤯.");
            GameOptions.AddToggle(GUID + ".sprint", "Make me sprint",
                getSaved: () => _sprint.Value,
                save: value => _sprint.Value = value);
            
            SprintSpeed = Config.Bind("General", "Sprint speed", 1.5f, "Sets sprint speed.");
            // Can't create GameOptions slider because ModFramework doesn't support sliders
            
            Logger.LogDebug("Registered settings.");
            
            var harmony = new Harmony(GUID+".patches");
            if (GameHooks.Require(GUID+".patches", SPRINTING_PATCH, PlayerPatch.TYPENAME, PlayerPatch.METHODNAME))
            {
                harmony.PatchAll(typeof(PlayerPatch));
                DragnSpringMod.ManualLog.LogDebug($"Applied patch {SPRINTING_PATCH}");
            }
            harmony.PatchAll();
            
            Logger.LogInfo("Mod initialized!");
        }

    }
}
