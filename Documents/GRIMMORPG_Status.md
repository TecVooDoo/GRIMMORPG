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
- GDD updated to v0.3 (modular stack, 2.5D perspective, standalone project)
- Documentation updated (Status, DevReference, GDD)

### What's Next
1. **Remove Adventure Creator** from project
2. **Install modular stack assets:**
   - Easy Save 3 (save/load)
   - Dialogue System for Unity (dialogue, quests, variables)
   - Ink + Ink Integration (branching narrative)
   - Animancer Pro (animation)
   - Text Animator (text effects)
   - Inventory Framework 2 (items/containers)
   - DOTween Pro (tweening)
   - Odin Inspector (inspector/serialization)
   - PlayMaker (optional -- visual puzzle logic)
   - Cinemachine (camera -- likely already via URP)
3. **Build custom systems:**
   - Click-to-move controller (NavMeshAgent + camera raycast)
   - Hotspot/interaction system
   - Cursor manager
   - Scene transition manager
   - Game bootstrap
4. **Set up BeatriceRoom as first playable:**
   - NavMesh bake on floor
   - Cinemachine camera positioned
   - Beatrice player controller walking
   - First hotspot interactions (computer, grimoire, etc.)
5. **Set up GitHub repo**

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

---

## Known Issues

| Issue | Severity | Notes |
|-------|----------|-------|
| AC still imported | Low | Needs removal -- no longer used |

---

**End of Status**
