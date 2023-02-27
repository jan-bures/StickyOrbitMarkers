using HarmonyLib;
using SpaceWarp.API.Mods;

namespace StickyOrbitMarkers
{
    [MainMod]
     public class StickyOrbitMarkersMod: Mod
    {
        public override void OnInitialized()
        {
            var harmony = new Harmony(typeof(StickyOrbitMarkersMod).Assembly.FullName);
            harmony.PatchAll();

            Logger.Info("Sticky Orbit Markers mod is initialized");
        }
    }
}