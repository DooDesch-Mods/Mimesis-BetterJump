using System;
using BetterJump.Runtime;
using DooDesch;
using MelonLoader;
using UnityEngine;

namespace BetterJump.Config
{
	internal static class BetterJumpPreferences
	{
		private const string CategoryId = "BetterJump";

		private static MelonPreferences_Category _category;
		private static MelonPreferences_Entry<bool> _enabled;
		private static MelonPreferences_Entry<float> _jumpVelocity;
		private static MelonPreferences_Entry<float> _forceUngroundTime;
		private static MelonPreferences_Entry<float> _airGravityScale;
		private static MelonPreferences_Entry<bool> _debugLogs;
		private static HostSettings _hostSettings;
		private static HostSetting<bool> _hostEnabled;
		private static HostSetting<float> _hostJumpVelocity;
		private static HostSetting<float> _hostForceUngroundTime;
		private static HostSetting<float> _hostAirGravityScale;
		private static HostSetting<float> _landSettleSeconds;
		private static HostSetting<float> _apexBlendSpeed;
		private static HostSetting<float> _maxAirGravitySeconds;

		internal static void Initialize()
		{
			if (_category != null)
			{
				return;
			}

			_category = MelonPreferences.CreateCategory(CategoryId, "BetterJump");
			_enabled = CreateEntry("Enabled", true, "Enabled", "Enable BetterJump functionality. When disabled, the mod will not modify jump behavior.");
			_jumpVelocity = CreateEntry("JumpVelocity", 4.8f, "Jump Velocity", "Upward speed applied when a jump starts (units/second). Higher values result in stronger jumps. Default: 4.8");
			_forceUngroundTime = CreateEntry("ForceUngroundTime", 0.08f, "Force Unground Time", "Seconds to keep avatar airborne before the next ground check can succeed. This prevents the game from immediately detecting the ground after a jump, allowing for better jump responsiveness. Default: 0.08");
			_airGravityScale = CreateEntry("AirGravityScale", 0.7f, "Air Gravity Scale", "Gravity multiplier applied during the fast part of the RISE (lower = floatier, higher arc). Near the apex it blends back to normal gravity so there is no hovering 'platform' at the top, and the descent always uses normal gravity for crisp landings. 1.0 disables the effect. Default: 0.7");
			_debugLogs = CreateEntry("DebugLogs", false, "Debug Logs", "Enable detailed debug logging for troubleshooting jump behavior.");

			_hostSettings = new HostSettings(CategoryId);
			_hostEnabled = _hostSettings.Register(_enabled, false, live: true);
			_hostJumpVelocity = _hostSettings.Register(_jumpVelocity, 0f, value => value >= 0, live: true, localValue: () => Mathf.Max(0f, _jumpVelocity.Value));
			_hostForceUngroundTime = _hostSettings.Register(_forceUngroundTime, 0.01f, value => value >= 0.01f, live: true, localValue: () => Mathf.Max(0.01f, _forceUngroundTime.Value));
			_hostAirGravityScale = _hostSettings.Register(_airGravityScale, 1f, value => value >= 0.1f && value <= 1f, live: true, localValue: () => Mathf.Clamp(_airGravityScale.Value, 0.1f, 1f));
			_landSettleSeconds = _hostSettings.Register(CreateEntry("LandSettleSeconds", 0.15f, "Landing Settle Time", "Host setting, live. Continuous ground contact required before another boosted jump. Seconds, at least 0.01. Default: 0.15"), 0.15f, value => value >= 0.01f, live: true, legacy: false);
			_apexBlendSpeed = _hostSettings.Register(CreateEntry("ApexBlendSpeed", 2.5f, "Apex Blend Speed", "Host setting, live. Rising speed below which gravity blends back to normal. Positive units/second. Default: 2.5"), 2.5f, value => value > 0f, live: true, legacy: false);
			_maxAirGravitySeconds = _hostSettings.Register(CreateEntry("MaxAirGravitySeconds", 8f, "Air Gravity Timeout", "Host setting, live for the next jump. Maximum time before reduced gravity is released. Positive seconds. Default: 8"), 8f, value => value > 0f, live: true, legacy: false);
			_hostSettings.EffectiveValuesChanged += JumpRuntimeState.Reset;
			_hostSettings.LiveValuesChanged += JumpRuntimeState.Reset;
		}

		private static MelonPreferences_Entry<T> CreateEntry<T>(string identifier, T defaultValue, string displayName, string description = null)
		{
			if (_category == null)
			{
				throw new InvalidOperationException("Preference category not initialized.");
			}

			return _category.CreateEntry(identifier, defaultValue, displayName, description);
		}

		internal static bool Enabled => _hostEnabled?.Value ?? false;

		internal static float JumpVelocity => Mathf.Max(0f, _hostJumpVelocity?.Value ?? 0f);

		internal static float ForceUngroundTime => Mathf.Max(0.01f, _hostForceUngroundTime?.Value ?? 0.01f);

		internal static float AirGravityScale => Mathf.Clamp(_hostAirGravityScale?.Value ?? 1f, 0.1f, 1f);

		internal static bool DebugLogs => _debugLogs.Value;
		internal static float LandSettleSeconds => _landSettleSeconds?.Value ?? 0.15f;
		internal static float ApexBlendSpeed => _apexBlendSpeed?.Value ?? 2.5f;
		internal static float MaxAirGravitySeconds => _maxAirGravitySeconds?.Value ?? 8f;
	}
}

