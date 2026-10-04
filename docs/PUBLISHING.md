# Publishing 0.1.0

## Before upload

1. Pull `main` after merging the release PR.
2. Build Release:
   ```bash
   dotnet build Source/TradeLock/TradeLock.csproj -c Release
   ```
3. Confirm `1.6/Assemblies/TradeLock.dll` exists.
4. Add `About/Preview.png`.
   - Recommended: 1280x720 or 640x360.
   - Steam requires the PNG to be under 1 MB.
5. Do not create `About/PublishedFileId.txt` manually before the first upload.

## Steam Workshop upload

RimWorld 1.6 can upload a local mod from the vanilla mod manager:

1. Enable Development Mode.
2. Open Mods.
3. Select Trade Lock.
4. Open Advanced.
5. Choose Upload to Steam Workshop.
6. Complete the first upload.
7. Steam/RimWorld will create `About/PublishedFileId.txt`.
8. Keep that file: it is required to update the same Workshop item later.
9. Set the Workshop item visibility to Public when ready.

Use the BBCode from `docs/WORKSHOP.md` as the Workshop description.

Suggested Workshop tags:
- Mod
- 1.6
- Utilities / Interface, if available in the uploader

Required dependency:
- Harmony (Workshop ID 2009463077)

## After first Steam upload

1. Commit `About/PublishedFileId.txt` to the repository.
2. Replace the `<url>` in `About/About.xml` with the final Workshop page URL if Workshop should be the primary link.
3. Create Git tag:
   ```bash
   git tag -a v0.1.0 -m "Trade Lock 0.1.0"
   git push origin v0.1.0
   ```
4. Create GitHub Release `v0.1.0` from that tag.

## GitHub release notes

### Trade Lock 0.1.0

Initial public release.

- Per-storage trade locking for visiting ground traders.
- Vanilla stockpile and storage-building support.
- Adaptive Storage Framework compatibility.
- Multi-selection toggling.
- Save-game persistence.
- Optional gizmo visibility setting.
- English and Russian localization.
