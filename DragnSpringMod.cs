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
    [BepInDependency(ModFramework.Guid, "1.3.0")]
    public class DragnSpringMod : BaseUnityPlugin
    {
        public static DragnSpringMod Singleton;
        public static ManualLogSource ManualLog;
        
        public const string GUID = "extrudeous.dragnsprint";
        public const string MOD_NAME = "Drag'n Sprint";
        public const string MOD_DESCRIPTION = "Adds sprint to the player.";
        public const string MOD_WEBSITE = "https://github.com/Extrudeous-101/DragnSprint";
        public const string MOD_UPDATE_REPO = "Extrudeous-101/DragnSprint";
        public static readonly string[] MOD_AUTHORS = new[] { "Extrudeous" };

        private const string SPRINTING_PATCH = "Sprinting";
    
        public ConfigEntry<bool> EnableSprint;
        public ConfigEntry<float> SprintSpeed;
        public ConfigEntry<KeyCode> SprintButton;
        
        Harmony _harmony = new Harmony(GUID+".patches");
    
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
                Website = MOD_WEBSITE,
                UpdateRepository = MOD_UPDATE_REPO
            });
            Logger.LogDebug("Registered mod.");
            
            EnableSprint = Config.Bind("General", "Use sprint", true, "Makes you sprint (◉ _ ◉).");
            GameOptions.AddToggle(GUID + ".sprint", "Use sprint",
                getSaved: () => EnableSprint.Value,
                save: value => EnableSprint.Value = value);
            
            SprintSpeed = Config.Bind("General", "Sprint speed modifier", 1.5f, "Sets sprint speed modifier.");
            GameOptions.AddSlider(GUID+".sprintSpeed", "Sprint speed modifier", 0.01f, 0.05f, 5f,
                getSaved: () => SprintSpeed.Value,
                save: value => SprintSpeed.Value = value);
            
            SprintButton = Config.Bind("General", "Sprint button", KeyCode.LeftShift, "Sets sprint button. \n" +
                "(and yes, we can't change this button selector)");
            // Can't create GameOptions button selector because this game doesn't have key mapping
            
            Logger.LogDebug("Registered settings.");
            
            if (GameHooks.Require(GUID+".patches", SPRINTING_PATCH, PlayerPatch.TYPENAME, PlayerPatch.METHODNAME))
            {
                _harmony.PatchAll(typeof(PlayerPatch));
                DragnSpringMod.ManualLog.LogDebug($"Applied patch {SPRINTING_PATCH}");
            }
            _harmony.PatchAll();
            
            Logger.LogInfo("Mod initialized!");
        }

        private void OnDestroy()
        {
            _harmony.UnpatchSelf();
        }
    }
}
