using Pool.Entities.Enums;

namespace Pool.Entities.Models;

/// <summary>
/// Показатель бассейна в момент времени
/// </summary>
public sealed class PoolIndicator
{
	// ReSharper disable once UnusedAutoPropertyAccessor.Global
	public int Id { get; init; }
	public string PoolAlias { get; init; } = default!;

	// ReSharper disable once UnusedAutoPropertyAccessor.Global
	public string ControllerCode { get; init; } = default!;
	public DateTimeOffset Date { get; init; }
	public DeviceType Type { get; init; }
	public double Value { get; init; }
}