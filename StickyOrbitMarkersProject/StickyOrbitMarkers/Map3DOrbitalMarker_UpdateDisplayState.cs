using HarmonyLib;
using KSP.Map;
using KSP.UI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace StickyOrbitMarkers
{
    [HarmonyPatch(typeof(Map3DOrbitalMarker), "UpdateDisplayState")]
    public class Map3DOrbitalMarker_UpdateDisplayState
    {
        public static bool Prefix(Map3DOrbitalMarker __instance)
		{
            var instanceRef = Traverse.Create(__instance);
            var staticRef = Traverse.Create<Map3DOrbitalMarker>();
            var _isPinned = instanceRef.Field("_isPinned");

            List<RaycastResult> currentRaycastResults = UIRaycaster.GetCurrentRaycastResults();
            if (!_isPinned.GetValue<bool>() && (currentRaycastResults == null || currentRaycastResults.Count <= 0)) {
                instanceRef.Method("Collapse").GetValue();
                return false;
            }
            bool flag = false;
            foreach (var t in currentRaycastResults)
            {
                if (t.gameObject.TryGetComponent(out Graphic x) &&
                    (x == instanceRef.Field("_collapsedObject").GetValue<Graphic>() || x == instanceRef.Field("_expandedObject").GetValue<Graphic>())
                   ) {
                    flag = true;
                }
            }
            if (flag && !instanceRef.Field("_lockToCollapsed").GetValue<bool>()) {
                if (!staticRef.Field("_isAnyHovered").GetValue<bool>()) {
                    instanceRef.Method("Expand").GetValue();
                    instanceRef.Field("_isHovered").SetValue(true);
                    staticRef.Field("_isAnyHovered").SetValue(true);
                }
                if (instanceRef.Field("_isHovered").GetValue<bool>() && Mouse.Right.WasPressedThisFrame()) {
                    instanceRef.Field("_isPinned").SetValue(!instanceRef.Field("_isPinned").GetValue<bool>());
                    return false;
                }
            } else if (instanceRef.Field("_isHovered").GetValue<bool>()) {
                instanceRef.Field("_isHovered").SetValue(false);
                staticRef.Field("_isAnyHovered").SetValue(false);
                if (!instanceRef.Field("_isPinned").GetValue<bool>()) {
                    instanceRef.Method("Collapse").GetValue();
                }
            }

            return false;
        }
    }
}