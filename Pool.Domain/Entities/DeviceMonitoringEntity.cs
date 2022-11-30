using JetBrains.Annotations;
using Pool.Domain.Enums;

namespace Pool.Domain.Entities;

public sealed class DeviceMonitoringEntity
{
	[UsedImplicitly]
	public int Id { get; init; }
	public string PoolAlias { get; init; } = default!;
	public string ControllerCode { get; init; } = default!;
	public DateTimeOffset Date { get; init; }
	public DeviceType Type { get; init; }
	public double Value { get; init; }
}