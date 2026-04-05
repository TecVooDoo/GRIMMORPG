# GRIMMORPG -- Dev Reference

**Last Updated:** April 4, 2026

---

## Project Overview

- **Type:** Point-and-Click Horror Adventure (2.5D)
- **Stack:** Modular -- Dialogue System + Ink + Animancer Pro + Easy Save 3 + Inventory Framework 2 + Text Animator + Cinemachine + custom scripts
- **Engine:** Unity 6 (6000.x), URP
- **Root:** `Assets/_GRIMMORPG/`
- **Perspective:** 2.5D (fixed cameras, 3D geometry, NavMesh pathfinding)

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

*None yet. Add overrides or extensions to universal conventions here as they emerge.*

---

## Lessons Learned

*Capture non-obvious discoveries, gotchas, and decisions here as development progresses.*
