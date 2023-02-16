using Pool.Entities.Enums;

namespace Pool.Entities.Models;

public sealed class DeviceIndicatorValue
{
	public DeviceIndicatorValue(DeviceType type, double? value)
	{
		Type = type;
		Value = value;
	}

	public DeviceType Type { get; }
	public double? Value { get; }
}