using Verse;

namespace TradeLock;

public sealed class TradeLockSettings : ModSettings
{
    public bool showTradeToggle = true;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref showTradeToggle, "showTradeToggle", true);
        base.ExposeData();
    }
}
