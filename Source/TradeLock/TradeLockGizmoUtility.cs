using RimWorld;
using Verse;

namespace TradeLock;

internal static class TradeLockGizmoUtility
{
    public static Gizmo For(Building_Storage storage)
    {
        var component = storage.Map.GetComponent<MapComponent_TradeLock>();

        return new Command_Toggle
        {
            defaultLabel = "TradeLock.AllowTrading".Translate(),
            defaultDesc = "TradeLock.AllowTradingDesc".Translate(),
            icon = TexCommand.ForbidOff,
            isActive = () => !component.IsLocked(storage),
            toggleAction = () => component.SetLocked(storage, !component.IsLocked(storage))
        };
    }

    public static Gizmo For(Zone_Stockpile stockpile)
    {
        var component = stockpile.zoneManager.map.GetComponent<MapComponent_TradeLock>();

        return new Command_Toggle
        {
            defaultLabel = "TradeLock.AllowTrading".Translate(),
            defaultDesc = "TradeLock.AllowTradingDesc".Translate(),
            icon = TexCommand.ForbidOff,
            isActive = () => !component.IsLocked(stockpile),
            toggleAction = () => component.SetLocked(stockpile, !component.IsLocked(stockpile))
        };
    }
}
