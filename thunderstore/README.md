# MIMESIS - BetterJump

> 🛟 **Need help or found a bug?** Get support at [support.doodesch.de/betterjump](https://support.doodesch.de/betterjump).


> Makes jumping in Mimesis actually useful - the stock jump is near-useless for getting around, so BetterJump retunes it (stronger configurable jump plus a brief forced-airborne window) to clear gaps and obstacles reliably.

![Version](https://img.shields.io/badge/version-1.6.0-blue)
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
- Uses your normal jump key - no input rebinding.

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

BetterJump reads private jump and ground state through MimicAPI and will not function without it. Installing through a mod manager pulls in MimicAPI (`NeoMimicry-MimicAPI-0.3.0`) and MelonLoader automatically.

For Nexus, install [MimicAPI 0.4.3](https://www.nexusmods.com/mimesis/mods/11) separately. Keep one `Mods/MimicAPI.dll`; the mod archive does not include it. Thunderstore resolves its existing MimicAPI dependency through the mod manager.

## Installation

- **Recommended:** install with a Thunderstore mod manager (r2modman or Gale). It installs MelonLoader and MimicAPI for you - just click Install.
- **Manual:**
  1. Install [MelonLoader](https://github.com/LavaGang/MelonLoader) 0.7.3+ into MIMESIS.
  2. Place both `BetterJump.dll` and `MimicAPI.dll` into `MIMESIS/Mods/`.
  3. Launch the game once to generate the configuration file at `UserData/MelonPreferences.cfg`.

## Configuration

Stored in `UserData/MelonPreferences.cfg` under `[BetterJump]`.

Gameplay settings follow the lobby host without overwriting saved client preferences. Without the mod on the host, clients use vanilla behavior. Live settings apply after the host changes them through a MelonPreferences UI or reloads the preferences; editing the file alone does not reload it. Use the same current mod version on host and clients for the new options and live updates. Older versions retain their initial legacy snapshot. Invalid new values use the registered default with a warning.

All gameplay settings below are live. `MaxAirGravitySeconds` applies to the next jump. `DebugLogs` stays local.

| Option | Default | Range and effect |
|---|---|---|
| `Enabled` | `true` | Enable boosted jumping. |
| `JumpVelocity` | `4.8` | Upward speed; at least 0. |
| `ForceUngroundTime` | `0.08` | Forced airborne seconds; at least 0.01, effective takeoff hold at least 0.02. |
| `AirGravityScale` | `0.7` | Ascent gravity multiplier, 0.1-1. Descent remains native. |
| `LandSettleSeconds` | `0.15` | Continuous ground contact before another boosted jump; at least 0.01 seconds. |
| `ApexBlendSpeed` | `2.5` | Positive rising speed below which gravity blends back to normal. |
| `MaxAirGravitySeconds` | `8` | Positive timeout for the reduced-gravity phase. |
| `DebugLogs` | `false` | Local detailed logging. |

## Usage

There is no keybind - just use your normal in-game jump input. BetterJump hooks the game's jump and ground-check logic, so jumping simply feels stronger and more responsive.

- Raise `JumpVelocity` for higher jumps; adjust `ForceUngroundTime` if jumps feel cut short.
- Set jump rules in the host configuration before creating the lobby, or change safe rules live through a preferences UI.
- Effects apply only to your own avatar.

Source and license (MIT, Copyright (c) 2025 DooDesch): [github.com/DooDesch-Mods/Mimesis-BetterJump](https://github.com/DooDesch-Mods/Mimesis-BetterJump).

## Images

Gallery images are captured in MIMESIS; release artwork uses real game photos.

Built against MIMESIS 0.4.0 / MelonLoader 0.7.3.
