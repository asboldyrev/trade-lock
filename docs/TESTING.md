# Manual test checklist

Use this checklist before release or after changes to trade filtering, storage detection, saving, or UI.

## Build

- `dotnet build Source/TradeLock/TradeLock.csproj -c Release`
- Build finishes with 0 errors.
- Preferably build finishes with 0 warnings.

## Vanilla stockpile

1. Create stockpile A and stockpile B.
2. Put the same resource in both.
3. Leave A trade-enabled.
4. Disable trading for B.
5. Open trade with a visiting ground trader.
6. Verify only the amount stored in A is offered.

## Vanilla storage building

Repeat the stockpile test with vanilla shelves.

## Moving items

1. Put an item in locked storage.
2. Verify it is absent from ground trade.
3. Move it to unlocked storage.
4. Verify it becomes available without changing the item itself.

## Save/load

1. Lock at least one stockpile and one storage building.
2. Save.
3. Reload.
4. Verify both remain locked.

## Multi-selection

1. Select multiple vanilla storage buildings.
2. Toggle Allow trading.
3. Verify the state changes for all selected compatible buildings.
4. Repeat with modded storage.

## Mod settings

1. Open Trade Lock settings.
2. Disable the storage trade toggle.
3. Verify the gizmo disappears.
4. Verify existing locked storage remains excluded from ground trade.
5. Re-enable the setting and verify the gizmo returns.

## Compatibility targets

Repeat the relevant storage test with:

- Adaptive Storage Framework
- [sbz] Bookcase
- [sbz] Fridge
- [sbz] Neat Storage

## Non-goals regression check

Verify Trade Lock does not affect:

- orbital trading;
- player caravan loading;
- normal hauling;
- recipe ingredient access;
- storage filters;
- forbidden state.
