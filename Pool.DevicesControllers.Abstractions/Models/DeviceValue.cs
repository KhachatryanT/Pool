using Pool.Domain.Enums;

namespace Pool.DevicesControllers.Abstractions.Models;

public class DeviceValue
{
	public DateTimeOffset Date { get; init; }
	public DeviceType Type { get; init; }
	public double Value { get; init; }
}