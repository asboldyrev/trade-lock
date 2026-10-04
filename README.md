# Trade Lock

Trade Lock is a RimWorld 1.6 QoL mod that lets you exclude selected storage from trade with visiting ground traders.

## Features

- Toggle trade availability per stockpile or storage building.
- Supports vanilla stockpile zones and vanilla storage buildings.
- Works with Adaptive Storage Framework through RimWorld's normal storage APIs, without hard-coded defNames.
- Multi-select several storage buildings or stockpiles and change them together.
- Trade lock state is saved with the game.
- Optional setting to hide the Trade Lock gizmo.
- English and Russian localization.
- Ground traders only: orbital trading and player caravan loading are intentionally unchanged.

## Compatibility

Verified architecture targets:

- Vanilla stockpile zones
- Vanilla shelves / `Building_Storage`
- Adaptive Storage Framework
- [sbz] Bookcase
- [sbz] Fridge
- [sbz] Neat Storage

Trade Lock integrates through `Building_Storage`, `SlotGroup` and `ThingOwner`, so many other storage mods should work automatically.

## How it works

Storage is trade-enabled by default.

Select a stockpile or storage building and disable:

- **Allow trading**
- **Разрешить торговлю**

Items stored there are removed from the goods offered to visiting ground traders.

The lock belongs to the storage, not to the item. Moving an item from a locked storage to an unlocked one immediately makes it available for trade again.

## Building

The project does not redistribute RimWorld or Harmony assemblies.

Set local reference paths:

```bash
export RIMWORLD_MANAGED_DIR="/path/to/RimWorld/RimWorldLinux_Data/Managed"
export HARMONY_DLL="/path/to/0Harmony.dll"

dotnet build Source/TradeLock/TradeLock.csproj -c Release
```

On Windows, `RIMWORLD_MANAGED_DIR` normally points to `RimWorldWin64_Data/Managed`.

The build writes:

```text
1.6/Assemblies/TradeLock.dll
```

## Development

See `docs/TESTING.md` for the current manual regression checklist.

## License

MIT.
