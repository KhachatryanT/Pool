using JetBrains.Annotations;
using Pool.DevicesControllers.Abstractions.Models;

namespace Pool.DevicesControllers.Settings;

internal sealed class DeviceSettings
{
	public DeviceType Type { get; [UsedImplicitly] init; }
	public bool Enabled { get; [UsedImplicitly] init; }
}