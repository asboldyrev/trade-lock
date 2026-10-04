using HarmonyLib;
using Verse;

namespace TradeLock;

[StaticConstructorOnStartup]
internal static class Bootstrap
{
    internal const string HarmonyId = "asboldyrev.tradelock";

    static Bootstrap()
    {
        new Harmony(HarmonyId).PatchAll();
        Log.Message("[Trade Lock] Loaded.");
    }
}
