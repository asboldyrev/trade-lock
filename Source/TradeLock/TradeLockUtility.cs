using RimWorld;
using Verse;

namespace TradeLock;

internal static class TradeLockUtility
{
    public static bool IsTradeLocked(Thing thing, Map fallbackMap = null)
    {
        if (thing == null)
        {
            return false;
        }

        var map = thing.MapHeld ?? fallbackMap;
        if (map == null)
        {
            return false;
        }

        var component = map.GetComponent<MapComponent_TradeLock>();

        // Vanilla stockpiles, vanilla storage buildings and Adaptive Storage
        // Framework all expose their current storage through SlotGroup.
        var slotGroup = thing.GetSlotGroup();
        if (slotGroup?.parent is Building_Storage storage)
        {
            return component.IsLocked(storage);
        }

        if (slotGroup?.parent is Zone_Stockpile stockpile)
        {
            return component.IsLocked(stockpile);
        }

        // Some modded storages keep items in a ThingOwner instead of spawning
        // them directly in storage cells. Walk the ownership chain as a
        // compatibility fallback.
        IThingHolder holder = thing.ParentHolder;
        while (holder != null)
        {
            if (holder is Building_Storage heldStorage)
            {
                return component.IsLocked(heldStorage);
            }

            if (holder is Thing holderThing)
            {
                holder = holderThing.ParentHolder;
                continue;
            }

            break;
        }

        return false;
    }
}
