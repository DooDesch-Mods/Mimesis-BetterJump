# MIMESIS - BetterJump

> 🛟 **Need help or found a bug?** Get support at [support.doodesch.de/betterjump](https://support.doodesch.de/betterjump).


> Makes jumping in Mimesis actually useful - the stock jump is near-useless for getting around, so BetterJump retunes it (stronger configurable jump plus a brief forced-airborne window) to clear gaps and obstacles reliably.

![Version](https://img.shields.io/badge/version-1.5.8-blue)
![Game](https://img.shields.io/badge/game-MIMESIS-purple)
![MelonLoader](https://img.shields.io/badge/MelonLoader-0.7.3+-green)
![Status](https://img.shields.io/badge/status-working-brightgreen)

![BetterJump in MIMESIS](https://raw.githubusercontent.com/DooDesch-Mods/Mimesis-BetterJump/main/docs/img/header.jpg)

---

## Features

- Retunes your local player's jump so it is actually useful for map traversal (the default jump is near-useless).
- Configurable upward jump velocity (default `4.8` units/second) - raise it for higher, stronger jumps.
- Configurable "force unground" window after takeoff that keeps you airborne briefly so the game does not instantly re-detect the ground, improving jump responsiveness (default `0.08s`).
- Applies to each modded player's own avatar and only triggers from the ground. Jump rules follow the lobby host.
- Single `Enabled` toggle to switch the mod on/off without uninstalling, plus an optional `DebugLogs` switch for troubleshooting.
- Implemented via Harmony patches on the game's existing jump and ground-check logic - no input rebinding, uses your normal jump key.

## Screenshots

![First-person view during a native jump with BetterJump enabled](https://raw.githubusercontent.com/DooDesch-Mods/Mimesis-BetterJump/main/docs/img/mid-jump.jpg)

A real jump in the isolated MIMESIS session, using the normal jump action.

![The same view after landing in the MIMESIS maintenance area](https://raw.githubusercontent.com/DooDesch-Mods/Mimesis-BetterJump/main/docs/img/grounded.jpg)

The same direction after landing. Both captures use BetterJump.

## Requirements

| Component | Version |
|---|---|
| MIMESIS | 0.4.0 |
| MelonLoader | 0.7.3+ |
| MimicAPI | Required - MimicAPI 0.4.3, [Nexus download](https://www.nexusmods.com/mimesis/mods/11), install separately |

> BetterJump reads private jump/ground state through MimicAPI's reflection helpers and will not function without it. A Thunderstore mod manager resolves it automatically as `NeoMimicry-MimicAPI-0.3.0`.

For Nexus, install [MimicAPI 0.4.3](https://www.nexusmods.com/mimesis/mods/11) separately. Keep one `Mods/MimicAPI.dll`; the mod archive does not include it. Thunderstore resolves its existing MimicAPI dependency through the mod manager.

## Installation

- **Recommended:** install via a Thunderstore mod manager (r2modman or Gale) - it pulls in MelonLoader and MimicAPI for you.
- **Manual:**
  1. Download `BetterJump.dll` from the [Releases page](https://github.com/DooDesch-Mods/Mimesis-BetterJump/releases).
  2. Make sure `MimicAPI.dll` is also present in your `Mods/` folder.
  3. Drop both DLLs into `MIMESIS/Mods/`.
  4. Launch the game once to generate the configuration file at `UserData/MelonPreferences.cfg`.

## Configuration

Stored in `UserData/MelonPreferences.cfg` under the `BetterJump` category.

Each Steam lobby uses a snapshot of the host's `Enabled`, `JumpVelocity`, `ForceUngroundTime` and `AirGravityScale` settings. Clients use that snapshot without overwriting their saved configuration. `DebugLogs` stays local. If the host does not have BetterJump, clients use vanilla jump behavior. Change the host configuration before creating the next lobby.

| Option | Description | Default | Values/Range |
|---|---|---|---|
| `Enabled` | Enable BetterJump functionality. When disabled, the mod does not modify jump behavior. | `true` | `true` / `false` |
| `JumpVelocity` | Upward speed applied when a jump starts (units/second). Higher values result in stronger jumps. | `4.8` | Any value `>= 0` (negative values are clamped to `0` at runtime) |
| `ForceUngroundTime` | Seconds to keep the avatar airborne before the next ground check can succeed. Prevents the game from immediately detecting the ground after a jump, improving responsiveness. | `0.08` | Any value `>= 0.01` (clamped to a minimum of `0.01s`; the effective hold is at least `0.02s` at jump time) |
| `AirGravityScale` | Gravity multiplier during ascent. Blends back to normal gravity near the apex; descent uses normal gravity. | `0.7` | `0.1` - `1.0` (clamped at runtime) |
| `DebugLogs` | Enable detailed debug logging for troubleshooting jump behavior. | `false` | `true` / `false` |

## Usage

There is no keybind - just use your normal in-game jump input. BetterJump hooks the game's jump and ground-check logic, so jumping simply feels stronger and more responsive.

- Raise `JumpVelocity` for higher jumps; adjust `ForceUngroundTime` if jumps feel cut short.
- Set jump rules in the host's `UserData/MelonPreferences.cfg` (category `BetterJump`) before creating the lobby.
- Effects apply only to your own avatar.

## Compatibility

Built against MIMESIS 0.4.0 / MelonLoader 0.7.3. The effect applies only to your local avatar.

## Building (developers)

```
dotnet build -c Release
```

Targets `netstandard2.1`. References the game DLLs and MelonLoader from the shared workspace `lib/` set, and links MimicAPI via `ProjectReference` (`Private=false`) declared as a MelonLoader optional dependency. The shared deploy configuration defaults to `_Test/MIMESIS/Mods`.

## Credits / License

Created by **DooDesch**. Released under the **MIT License** (Copyright (c) 2025 DooDesch). Source and releases: [github.com/DooDesch-Mods/Mimesis-BetterJump](https://github.com/DooDesch-Mods/Mimesis-BetterJump).

## Images

Gallery images are captured in MIMESIS; release artwork uses real game photos.
