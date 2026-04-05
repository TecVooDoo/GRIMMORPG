# GRIMMORPG -- Game Design Document

**Developer:** TecVooDoo LLC
**Type:** Point-and-Click Horror Adventure
**Stack:** Modular (Dialogue System + Ink + Animancer Pro + Easy Save 3 + Inventory Framework 2 + Text Animator + Cinemachine + custom scripts)
**Project:** Standalone Unity 6 URP at `E:\Unity\GRIMMORPG`
**Tagline:** "A point-and-click horror adventure where the game you play starts playing you back."
**Inspirations:** Dante's Inferno, Ghost in the Machine, Sierra adventure games (King's Quest, Space Quest)

**Document Version:** 0.3
**Last Updated:** April 5, 2026

---

## 1. Premise

Beatrice, an orphaned indie game developer and greyhat hacker in her mid-20s, inherits a dark grimoire from a grandmother she never knew. Under crunch pressure to ship her delayed MMORPG, she uses the grimoire's spells as the basis for the game's magic system. When thousands of players launch the game and start casting, the spells work -- but the effects manifest in the real world, not the game. Demons appear. People start dying. Beatrice must find the grimoire's missing pages, patch the counter-spells into the game, and destroy the book before the Earth becomes the tenth circle of hell.

---

## 2. Core Concepts

### The Magic System Rule
**Intent + Precision = Magic.** Real-world spells require both human intent and precise execution. Computers handle precision perfectly. Players provide intent by clicking "Cast." Thousands of simultaneous casts amplify the spells beyond anything a single caster could achieve.

### Tech vs Magic Tradeoff (Core Mechanic)
When Beatrice casts a spell from the physical grimoire, it causes nearby technology to glitch. This creates a constant player choice:
- **Tech path:** Hacking, security systems, online research, server access. Requires working equipment.
- **Magic path:** Combat demons, break curses, interact with supernatural elements. Risks frying equipment needed for tech puzzles.
Some problems can only be solved with one approach. Some offer both options with different consequences.

### The Grimoire
- Inherited from Beatrice's grandmother via a will (despite Beatrice being an orphan -- why did Gran know about her?)
- Accompanied by a letter: *"Beatrice, Find the missing pages, reassemble this book and then destroy it. Love, Gran"*
- Contains complete spells AND incomplete spells (missing counter-spells on lost pages)
- The missing pages are the key collectibles -- each page found = a counter-spell that can be patched into the MMORPG
- Must be fully reassembled before it can be destroyed

### The Tenth Circle
Social media influencers, possessed by demons, spread misinformation claiming the game is safe and encouraging mass coordinated spellcasting at a designated hour. Their goal: fully open the gates of hell. Beatrice must stop the coordinated cast by finding the pages, batch-patching counter-spells into the game, and destroying the reassembled grimoire.

---

## 3. Characters

### Beatrice (Protagonist)
- **Age:** Mid-20s
- **Role:** Indie game developer, greyhat hacker
- **Name origin:** Beatrice from Dante's Divine Comedy -- Dante's guide through Paradise. Ironic: this Beatrice accidentally created a digital Inferno and must guide herself (and players) back out.
- **Background:** Orphan. Never knew her grandmother. Receives the grimoire through a will, which raises questions about her family history. Not elite-level hacker, but skilled enough to be dangerous. Under crunch pressure -- her MMORPG launch has been delayed multiple times.
- **Personality:** TBD (will emerge through writing)

### Gran (Deceased / Backstory)
- Beatrice's grandmother. Sent the grimoire and the warning letter.
- Why did she have it? Why didn't she destroy it herself? Why did she know Beatrice existed despite the orphan situation?
- Potential for backstory reveals through found letters, journal entries, or grimoire marginalia.

### The Influencers (Antagonists)
- Social media personalities possessed by demons.
- Spread misinformation encouraging mass spellcasting.
- May appear sympathetic/normal at first before possession is revealed.

---

## 4. World Structure

### Dual-World Potential
- **Real world:** Beatrice's apartment/office, city locations, places where pages are hidden
- **MMORPG world:** The game Beatrice built. May bleed into real world as the barrier weakens.
- **Open question:** Does gameplay happen inside the MMORPG, or only in the real world with the game as background context?

### Dante's Inferno Structure (Possible)
- 9 circles of hell reflected in MMORPG zone structure or escalating real-world demonic incursions
- The "tenth circle" is the final threat -- the coordinated mass cast that would fully merge the worlds

---

## 5. Puzzle Design Philosophy

### Sierra-Style Inventory Puzzles
- Grimoire pages as key collectibles
- Tech tools (laptop, phone, USB drives, network access) vs magical items (grimoire, spell components)
- Combining items, using items on hotspots

### The Tech/Magic Choice
- Some puzzles have dual solutions (hack vs cast)
- Casting has consequences (tech glitches)
- Creates replayability and emergent problem-solving

---

## 6. Technical Foundation

### Architecture: Modular Stack (Replaces Adventure Creator)
AC was evaluated in VNPC project (Sessions 6-9) and dropped. Two sessions of setup yielded a player that couldn't walk. Every AC feature has a better standalone alternative already owned. Modular stack gives full control, debuggability, and cross-project reuse.

### Core Stack
| Asset | Role |
|---|---|
| **Dialogue System for Unity** | Dialogue, quests, variables, Lua scripting |
| **Ink + Ink Integration** | Branching narrative, story logic |
| **Animancer Pro** | Animation (type-safe, no animator controllers) |
| **Easy Save 3** | Save/load system |
| **Inventory Framework 2** | Items, combining, containers (UI Toolkit) |
| **Text Animator** | Atmospheric text effects |
| **Cinemachine** | Camera management |
| **PlayMaker** | Visual puzzle logic (optional -- may use C# instead) |

### Custom Systems (To Build)
- Click-to-move controller (NavMeshAgent + camera raycast)
- Hotspot/interaction system (Look, Use, Talk per object)
- Cursor manager (interaction-specific cursors)
- Scene transition manager
- Game bootstrap / manager

### Engine
- Fixed-camera 3D perspective (pre-positioned cameras, full 3D geometry)
- Point And Click movement
- Mouse And Keyboard input
- Verb-first interaction (select action, then click target)
- Unity NavMesh pathfinding

---

## 7. Open Questions

- What is Gran's full backstory? Why couldn't she destroy the grimoire herself?
- Does Beatrice enter the MMORPG world, or does it come to her?
- How many grimoire pages / acts / locations?
- Is there a supporting cast (friends, other developers, players who figure out what's happening)?
- What does "destroying the grimoire" actually require? A final spell? A ritual? Something from Gran's letter?
- Does the tech-vs-magic tradeoff manifest in the UI (equipment damage meter, spell cooldowns)?

---

## 8. Design Decisions

| # | Decision | Status | Notes |
|---|----------|--------|-------|
| 1 | Stack: Modular (no Adventure Creator) | Locked | AC dropped after practical eval -- modular alternatives are superior in every domain |
| 2 | Fixed-camera 3D, point-and-click | Locked | Pre-positioned cameras, 3D geometry (Grim Fandango approach) |
| 3 | Protagonist is Beatrice (was Mary) | Locked | Dante's Beatrice parallel |
| 4 | Tech vs Magic as core mechanic | Proposed | Casting glitches tech -- player must choose approach |
| 5 | Grimoire pages as collectible spine | Proposed | Each page = counter-spell to patch into MMORPG |
| 6 | Verb-first interaction | Active | Custom implementation -- Look, Use, Talk, etc. |
| 7 | Story development approach: pantser | Locked | Story will evolve through writing, not rigid outlining |
| 8 | Standalone project (not under VNPC) | Locked | P&C and VN share nothing -- separate projects reduce friction |

---

**Note:** This GDD captures initial concept and design seeds. The story is explicitly in discovery mode -- details will evolve significantly through the writing process. This document tracks decisions as they crystallize, not as a rigid blueprint.

---

**End of GRIMMORPG GDD**
