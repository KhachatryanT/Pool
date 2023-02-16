using Pool.Entities.Enums;

namespace Pool.Entities.Models;

public sealed class NormalizedDeviceIndicatorValue
{
	public NormalizedDeviceIndicatorValue(DeviceType type, double? value, double? normalizedValue)
	{
		Type = type;
		Value = value;
		NormalizedValue = normalizedValue;
	}

	public DeviceType Type { get; }
	public double? Value { get; }
	public double? NormalizedValue { get; }
}