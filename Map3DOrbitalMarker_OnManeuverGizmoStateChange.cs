using HarmonyLib;
using KSP.Map;
using KSP.Messages;

namespace StickyOrbitMarkers
{
    [HarmonyPatch(typeof(Map3DOrbitalMarker), "OnManeuverGizmoStateChange")]
    public class Map3DOrbitalMarker_OnManeuverGizmoStateChange
    {
        public static bool Prefix(Map3DOrbitalMarker __instance, MessageCenterMessage msg)
        {
            ManeuverGizmoStateChange maneuverGizmoStateChange = (ManeuverGizmoStateChange)msg;

            var _maneuverGizmoActive = Traverse.Create(__instance).Field("_maneuverGizmoActive");
            if (maneuverGizmoStateChange.State == ManeuverGizmoState.Expanded ||
                maneuverGizmoStateChange.State == ManeuverGizmoState.CollapsedMenu ||
                maneuverGizmoStateChange.State == ManeuverGizmoState.Movement
            ) {
                _maneuverGizmoActive.SetValue(true);
            } else {
                _maneuverGizmoActive.SetValue(false);
            }

            return false;
        }
    }
}