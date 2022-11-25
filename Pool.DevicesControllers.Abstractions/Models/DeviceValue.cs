namespace Pool.DevicesControllers.Abstractions.Models;

public sealed class DeviceValue
{
	public DeviceType Type { get; init; }
	public double Value { get; init; }
}