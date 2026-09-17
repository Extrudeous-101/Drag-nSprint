using BepInEx;
using DragNWash.ModFramework;
using DragNWash.ModFramework.Text;
using UnityEngine;

namespace Extrudeous.DragnSprint;

[BepInPlugin(GUID, MOD_NAME, "1.0")]
[BepInDependency(ModFramework.Guid, BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency(GameText.Guid, BepInDependency.DependencyFlags.HardDependency)]
public class DragnSpringMod : BaseUnityPlugin
{
    public const string GUID = "extrudeous.dragnsprint";
    public const string MOD_NAME = "Drag'n Sprint";
    public const string MOD_DESCRIPTION = "Adds sprint to the player.";
    public const string MOD_WEBSITE = "https://github.com/Extrudeous-101/DragnSprint";
    public static readonly string[] MOD_AUTHORS = new[] { "Extrudeous" };
    
    private void Awake()
    {
        ModFramework.Register(new ModInfo
        {
            Guid = GUID,
            DisplayName = MOD_NAME,
            Description = MOD_DESCRIPTION,
            Authors = MOD_AUTHORS,
            Website = MOD_WEBSITE
        });
    }
}