using System.Collections.Generic;
using RimWorld;
using Verse;

namespace TradeLock;

public sealed class MapComponent_TradeLock : MapComponent
{
    private List<Building_Storage> lockedStorages = new();
    private List<Zone_Stockpile> lockedStockpiles = new();

    public MapComponent_TradeLock(Map map) : base(map)
    {
    }

    public bool IsLocked(Building_Storage storage)
    {
        return storage != null && lockedStorages.Contains(storage);
    }

    public bool IsLocked(Zone_Stockpile stockpile)
    {
        return stockpile != null && lockedStockpiles.Contains(stockpile);
    }

    public void SetLocked(Building_Storage storage, bool locked)
    {
        if (storage == null)
        {
            return;
        }

        if (locked)
        {
            if (!lockedStorages.Contains(storage))
            {
                lockedStorages.Add(storage);
            }
        }
        else
        {
            lockedStorages.Remove(storage);
        }
    }

    public void SetLocked(Zone_Stockpile stockpile, bool locked)
    {
        if (stockpile == null)
        {
            return;
        }

        if (locked)
        {
            if (!lockedStockpiles.Contains(stockpile))
            {
                lockedStockpiles.Add(stockpile);
            }
        }
        else
        {
            lockedStockpiles.Remove(stockpile);
        }
    }

    public override void ExposeData()
    {
        base.ExposeData();

        Scribe_Collections.Look(ref lockedStorages, "lockedStorages", LookMode.Reference);
        Scribe_Collections.Look(ref lockedStockpiles, "lockedStockpiles", LookMode.Reference);

        if (Scribe.mode == LoadSaveMode.PostLoadInit)
        {
            lockedStorages ??= new List<Building_Storage>();
            lockedStockpiles ??= new List<Zone_Stockpile>();

            lockedStorages.RemoveAll(storage => storage == null || storage.Destroyed);
            lockedStockpiles.RemoveAll(stockpile => stockpile == null);
        }
    }
}
