# Trade Lock

A RimWorld 1.6 QoL mod that lets you exclude selected storage from trade with visiting ground traders.

## Current scope

- Vanilla stockpile zones.
- Vanilla `Building_Storage` buildings (including shelves).
- Adaptive Storage Framework storage and mods based on it, without hard-coded defNames.
- English and Russian localization.
- Save-game persistence.
- Ground traders only. Orbital trading and player caravan loading are intentionally untouched.

## Compatibility targets

The initial implementation is designed to support:

- [sbz] Bookcase
- [sbz] Fridge
- [sbz] Neat Storage
- Adaptive Storage Framework

ASF storage inherits from RimWorld's `Building_Storage`, so Trade Lock integrates through the normal storage/slot-group API rather than checking individual mod definitions.

## Building

Set `RIMWORLD_DIR` to the RimWorld installation directory and build:

```bash
dotnet build Source/TradeLock/TradeLock.csproj -c Release
```

The project writes `TradeLock.dll` to `1.6/Assemblies/`.

On Linux, if the game directory layout differs from the Windows default paths in the project file, pass the reference paths or adjust `RimWorldDir`/HintPath values locally.

## Behavior

Storage is trade-enabled by default. Select a stockpile or storage building and toggle **Allow trading** / **Разрешить торговлю** off to hide its contents from visiting ground traders.

The lock belongs to the storage, not to the item. Moving an item from a locked storage to an unlocked one makes it available for trade again.
