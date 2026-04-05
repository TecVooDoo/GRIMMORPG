# GRIMMORPG -- Status

**Last Updated:** April 5, 2026

---

## Current State

Standalone Unity 6 URP project at `E:\Unity\GRIMMORPG`. Previously a sub-project under VNPC -- split out because P&C and VN games share nothing and were causing friction.

**Stack:** Modular (dropped Adventure Creator after practical eval -- see GDD v0.3 Section 6)

### What's Done
- Unity 6 project created with URP
- `Assets/_GRIMMORPG/` folder structure (Scripts, Art, Audio, Data, Prefabs, Scenes, Settings, UI)
- OpenUPM scoped registry added to manifest.json
- Phase 1 (Addressables) and Phase 2 (UniTask, TecVooDoo packages, MCP for Unity) in manifest.json
- BeatriceRoom scene imported (Room geometry: 7 wall/floor/ceiling pieces, Furniture: 29 props, Synty Sidekicks character)
- Synty + PolyPerfect + BodyPoser assets imported
- GDD updated to v0.3 (modular stack, fixed-camera 3D perspective, standalone project)
- Documentation updated (Status, DevReference, GDD)
- Full modular asset stack installed and verified (see DevReference for complete list)
- Synty Store Importer installed from GitHub
- Asset Inventory 4 installed for cherry-picking individual assets from owned packages
- Stack audit completed -- PlayMaker dropped, all core assets confirmed
- GitHub repo created (TecVooDoo/GRIMMORPG), initial commit pushed
- .gitignore configured (tracks only _GRIMMORPG/, Documents/, ProjectSettings/, Packages manifests)
- DevReference updated with "Assets Before Custom Code" rule and full asset lookup table

### What's Next
1. **Remove Adventure Creator** from project (still imported, no longer used)
2. **Build custom systems:**
   - Click-to-move controller (NavMeshAgent + camera raycast)
   - Hotspot/interaction system (Look, Use, Talk per object)
   - Cursor manager (using Synty DarkFantasyHUD cursors)
   - Scene transition manager
   - Game bootstrap / manager
3. **Set up BeatriceRoom as first playable:**
   - NavMesh bake on floor
   - Cinemachine camera positioned
   - Beatrice player controller walking
   - First hotspot interactions (computer, grimoire, etc.)

---

## Session Log

### Session 1 -- April 4, 2026
**Goal:** Initial project setup from NewProjectSetup_Brief

- Created standalone project (was previously under VNPC)
- Set up folder structure, manifest.json, documentation
- MCP config files created (port TBD -- needs Unity open)
- Added project to global `~/.claude/settings.json` additionalDirectories

### Session 2 -- April 5, 2026
**Goal:** Evaluate AC, decide on stack, update docs

- Practical evaluation of Adventure Creator after 2 sessions of use in VNPC project:
  - Two sessions of AC setup yielded a player that couldn't walk
  - Every AC feature mapped to a superior standalone alternative already owned
  - AC dropped in favor of modular stack
- BeatriceRoom scene exported from VNPC and imported
- GDD updated to v0.3 (modular stack, 2.5D, standalone project, new design decisions)
- DevReference updated (stack, perspective, AC rationale)
- Status updated with new roadmap

### Session 3 -- April 5, 2026
**Goal:** Finalize stack, set up repo, complete project setup

- Full stack audit against Sandbox_AssetLog (316 evaluated assets)
- Installed all core assets: Dialogue System, Ink, Easy Save 3, Text Animator, Inventory Framework 2 PRO, Animancer Pro, DOTween Pro, Master Audio, MegaBook 2, Odin Inspector, Ghost and Shader's PRO, Flexalon Pro, ALINE, Body Poser, 3D Object Image, Asset Inventory 4
- PlayMaker dropped (overkill for code-first P&C)
- Synty Store Importer installed from GitHub
- Synty asset inventory documented (1,653 animation clips, DarkFantasyHUD UI kit, PolygonParticleFX, SidekickCharacters)
- GitHub repo created: TecVooDoo/GRIMMORPG
- .gitignore configured to track only GRPG-owned files
- Initial commit pushed to main
- DevReference updated with "Assets Before Custom Code" rule and full asset/Synty lookup tables
- Setup phase complete -- ready to build custom systems

---

## Known Issues

| Issue | Severity | Notes |
|-------|----------|-------|
| AC still imported | Low | Needs removal -- no longer used |

---

**End of Status**
