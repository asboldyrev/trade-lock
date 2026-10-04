using UnityEngine;
using Verse;

namespace TradeLock;

public sealed class TradeLockMod : Mod
{
    internal static TradeLockSettings Settings { get; private set; }

    public TradeLockMod(ModContentPack content) : base(content)
    {
        Settings = GetSettings<TradeLockSettings>();
    }

    public override string SettingsCategory()
    {
        return "TradeLock.SettingsCategory".Translate();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listing = new Listing_Standard();
        listing.Begin(inRect);

        listing.CheckboxLabeled(
            "TradeLock.ShowTradeToggle".Translate(),
            ref Settings.showTradeToggle,
            "TradeLock.ShowTradeToggleDesc".Translate());

        listing.End();
    }
}
