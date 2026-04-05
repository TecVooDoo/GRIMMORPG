# GRIMMORPG -- Dev Reference

**Last Updated:** April 5, 2026

---

## Project Overview

- **Type:** Point-and-Click Horror Adventure (2.5D)
- **Stack:** Modular -- Dialogue System + Ink + Animancer Pro + Easy Save 3 + Inventory Framework 2 + Text Animator + Cinemachine + custom scripts
- **Engine:** Unity 6 (6000.x), URP
- **Root:** `Assets/_GRIMMORPG/`
- **Perspective:** Fixed-camera 3D (pre-positioned cameras, 3D geometry, NavMesh pathfinding)

### Why Not Adventure Creator
AC was evaluated in VNPC project (Sessions 6-9). Two sessions of setup produced a player that couldn't walk. Every AC feature (save, inventory, dialogue, animation, camera, pathfinding) has a superior standalone alternative already owned. Modular stack gives full control and debuggability. See GDD Section 6 for full stack breakdown.

---

## Architecture

*To be documented as systems are built.*

---

## Coding Standards

Follows TecVooDoo universal conventions (see `NewProjectSetup_Brief.md` Section 8):

- No `var` keyword -- explicit types always
- No per-frame allocations (no `new`, no LINQ in Update/FixedUpdate)
- ASCII only in code and docs
- `sealed` on MonoBehaviours unless inheritance is intended
- Prefer async/await (UniTask) over coroutines
- Prefer interfaces and generics
- GameEvent/GameEventListener custom event system (not SOAP)
- Vanilla ScriptableObject architecture
- Set state BEFORE firing events
- Extract by responsibility, not by line count
- Production-quality test code

### Unity 6 API Notes

| Old API | Unity 6 API |
|---------|-------------|
| `rb.velocity` | `rb.linearVelocity` |
| `collider.material` | `collider.sharedMaterial` (context-dependent) |

---

## Project-Specific Rules

### Assets Before Custom Code
Always prefer installed asset solutions over writing custom code. Every asset in this project was evaluated in Sandbox and chosen for a reason. Before implementing any system, check whether an installed asset already covers it. Writing custom code that duplicates asset functionality wastes time and creates maintenance burden.

### Installed Asset Stack (know when to use each)

| Asset | Use When... | MCP Tools |
|---|---|---|
| **Animancer Pro** | Any animation control -- state transitions, blending, clip playback. Replaces Animator Controllers. | -- |
| **ALINE** | Debug visualization -- drawing lines, shapes, paths in scene/game view | Yes |
| **Asset Inventory 4** | Browsing/importing individual items from owned Asset Store packages without full import. Claude can use this to search and import assets. | -- |
| **Audio Preview Tool** | Previewing audio clips in the editor | -- |
| **Body Poser** | Posing humanoid characters in scenes for screenshots, cutscenes, dressing | -- |
| **Cinemachine** | Camera management -- fixed perspectives, transitions, follow, virtual cameras | Yes |
| **Dialogue System for Unity** | Dialogue trees, quests, variables, Lua conditions, NPC relationships, localization | -- |
| **DOTween Pro** | Tweening anything -- UI, transforms, colors, values. Code-driven animation. | -- |
| **Easy Save 3** | Save/load -- player progress, settings, puzzle state, any persistent data | -- |
| **Flexalon Pro** | 3D and UI layouts -- arranging objects in grids, circles, curves, stacks | Yes |
| **Ghost and Shader's PRO** | Spectral/ghost visual effects for supernatural elements | -- |
| **Ink Integration** | Writing branching narrative in .ink files -- story logic, choices, variables | Yes |
| **Inventory Framework 2 PRO** | Item management -- inventory bags, equipment slots, drag-drop, stacking, crafting | -- |
| **Master Audio 2024** | Audio playback -- sound groups, playlists, bus mixing, pooling, ducking | -- |
| **MegaBook 2** | Physical book prop with turnable pages -- the grimoire | -- |
| **Markdown for Unity** | Rendering markdown in the editor | -- |
| **Odin Inspector** | Custom inspectors, serialization, validation, editor windows | -- |
| **Text Animator** | Animated text effects -- glitch, shake, wave, fade per-character. Horror atmosphere. | Yes |
| **3D Object Image (UI Toolkit)** | Rendering 3D objects as UI images -- inventory previews, item inspection | -- |
| **Ultimate Preview Window** | Enhanced asset preview in editor | -- |
| **vHierarchy 2 / vFolders 2 / vFavorites 2** | Editor QoL -- hierarchy colors/icons, project folder icons, favorites panel | -- |
| **Wingman** | Editor productivity tool | -- |

### Synty Art Assets (imported via Asset Inventory 4 or Synty Store Importer)

| Pack | Content Available |
|---|---|
| **AnimationBaseLocomotion** | Walk, run, sprint, crouch, strafe, jump, land, turns (Feminine/Masculine/Neutral, Polygon/Sidekick rigs) |
| **AnimationIdles** | 165+ idle variants -- phone, eating, leaning, scared, thoughtful, praying, postures |
| **AnimationEmotesAndTaunts** | 70+ social anims -- waves, bows, dances, taunts, celebrations |
| **SidekickCharacters** | Modular humans -- 4 HumanSpecies + 6 ModernCivilians with customization system |
| **InterfaceDarkFantasyHUD** | Full UI kit -- cursors, action bars, health, inventory icons, subtitles, minimap, fullscreen FX |
| **InterfaceCore** | Shared UI base -- input icons, social icons, shaders |
| **PolygonParticleFX** | 120+ VFX prefabs -- magic, fire, lightning, fog, portals, ritual circles, blood, weather |
| **PolygonSciFiWorlds** | Props/signs (minimal import) |
| **Additional Synty packs** | Available via SyntyPass + Asset Inventory 4 for cherry-picking individual props |

---

## Lessons Learned

*Capture non-obvious discoveries, gotchas, and decisions here as development progresses.*
