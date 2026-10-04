using System.Linq;
using RimWorld;
using Verse;

namespace TradeLock;

internal static class TradeLockGizmoUtility
{
    private const int TradeToggleGroupKey = 184726531;

    public static Gizmo For(Building_Storage storage)
    {
        var component = storage.Map.GetComponent<MapComponent_TradeLock>();

        return new Command_Toggle
        {
            defaultLabel = "TradeLock.AllowTrading".Translate(),
            defaultDesc = "TradeLock.AllowTradingDesc".Translate(),
            icon = TexCommand.ForbidOff,
            groupKey = TradeToggleGroupKey,
            isActive = () => !component.IsLocked(storage),
            toggleAction = () => ToggleSelectedStorages(storage)
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
            groupKey = TradeToggleGroupKey,
            isActive = () => !component.IsLocked(stockpile),
            toggleAction = () => ToggleSelectedStockpiles(stockpile)
        };
    }

    private static void ToggleSelectedStorages(Building_Storage source)
    {
        var component = source.Map.GetComponent<MapComponent_TradeLock>();
        var newLockedState = !component.IsLocked(source);

        var selectedStorages = Find.Selector.SelectedObjects
            .OfType<Building_Storage>()
            .Where(storage => storage.Spawned && storage.Map == source.Map && storage.Faction == Faction.OfPlayer)
            .ToList();

        if (selectedStorages.Count == 0)
        {
            selectedStorages.Add(source);
        }

        foreach (var storage in selectedStorages)
        {
            component.SetLocked(storage, newLockedState);
        }
    }

    private static void ToggleSelectedStockpiles(Zone_Stockpile source)
    {
        var map = source.zoneManager.map;
        var component = map.GetComponent<MapComponent_TradeLock>();
        var newLockedState = !component.IsLocked(source);

        var selectedStockpiles = Find.Selector.SelectedObjects
            .OfType<Zone_Stockpile>()
            .Where(stockpile => stockpile.zoneManager?.map == map)
            .ToList();

        if (selectedStockpiles.Count == 0)
        {
            selectedStockpiles.Add(source);
        }

        foreach (var stockpile in selectedStockpiles)
        {
            component.SetLocked(stockpile, newLockedState);
        }
    }
}
