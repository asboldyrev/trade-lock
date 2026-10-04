using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace TradeLock.Patches;

[HarmonyPatch(typeof(Building_Storage), nameof(Building_Storage.GetGizmos))]
internal static class Patch_BuildingStorage_GetGizmos
{
    private static IEnumerable<Gizmo> Postfix(IEnumerable<Gizmo> __result, Building_Storage __instance)
    {
        foreach (var gizmo in __result)
        {
            yield return gizmo;
        }

        if (__instance.Spawned && __instance.Faction == Faction.OfPlayer)
        {
            yield return TradeLockGizmoUtility.For(__instance);
        }
    }
}

[HarmonyPatch(typeof(Zone_Stockpile), nameof(Zone_Stockpile.GetGizmos))]
internal static class Patch_Stockpile_GetGizmos
{
    private static IEnumerable<Gizmo> Postfix(IEnumerable<Gizmo> __result, Zone_Stockpile __instance)
    {
        foreach (var gizmo in __result)
        {
            yield return gizmo;
        }

        yield return TradeLockGizmoUtility.For(__instance);
    }
}
