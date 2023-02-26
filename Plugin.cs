using HarmonyLib;
using SpaceWarp.API.Mods;

namespace StickyOrbitMarkers
{
    static class PluginInfo
    {
        public const string GUID = "StickyOrbitMarkers";
        public const string NAME = "Sticky Orbit Markers";
    }

    [MainMod]
    public class Plugin: Mod
    {
        public override void Initialize()
        {
            base.Initialize();

            var harmony = new Harmony(PluginInfo.GUID);
            harmony.PatchAll();

            Logger.Info($"Mod {PluginInfo.NAME} is initialized.");
        }
    }
}
