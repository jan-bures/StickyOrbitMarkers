using BepInEx;
using HarmonyLib;
using SpaceWarp;
using SpaceWarp.API.Mods;

namespace StickyOrbitMarkers
{
    [BepInPlugin(StickyOrbitMarkersMod.ModGuid, StickyOrbitMarkersMod.ModName, StickyOrbitMarkersMod.ModVer)]
    [BepInDependency(SpaceWarpPlugin.ModGuid, SpaceWarpPlugin.ModVer)]
    public class StickyOrbitMarkersMod : BaseSpaceWarpPlugin
    {
        public const string ModGuid = "com.munix.StickyOrbitMarkers";
        public const string ModName = "Sticky Orbit Markers";
        public const string ModVer = "0.3.0";

        public override void OnInitialized()
        {
            Harmony.CreateAndPatchAll(typeof(StickyOrbitMarkersMod).Assembly, StickyOrbitMarkersMod.ModGuid);
            Logger.LogInfo("Sticky Orbit Markers mod is initialized");
        }
    }
}