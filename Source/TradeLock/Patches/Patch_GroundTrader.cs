using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace TradeLock.Patches;

[HarmonyPatch(typeof(Pawn_TraderTracker), nameof(Pawn_TraderTracker.ColonyThingsWillingToBuy))]
internal static class Patch_GroundTrader
{
    private static void Postfix(Pawn playerNegotiator, ref IEnumerable<Thing> __result)
    {
        var map = playerNegotiator?.MapHeld;
        if (map == null || __result == null)
        {
            return;
        }

        __result = __result.Where(thing => !TradeLockUtility.IsTradeLocked(thing, map));
    }
}
