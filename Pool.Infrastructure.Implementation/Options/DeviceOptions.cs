using JetBrains.Annotations;
using Pool.Entities.Enums;

namespace Pool.Infrastructure.Implementation.Options;

internal sealed class DeviceOptions
{
	public DeviceType Type { get; [UsedImplicitly] init; }
	public bool Enabled { get; [UsedImplicitly] init; }
}