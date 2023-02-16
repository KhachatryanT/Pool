using Pool.Entities.Enums;

namespace Pool.Entities.Models;

/// <summary>
/// Показатель устройства
/// </summary>
public sealed class IndicatorOfDevice
{
	public IndicatorOfDevice(DeviceType type, IndicatorValue indicator)
	{
		Type = type;
		Indicator = indicator;
	}

	public DeviceType Type { get; }
	public IndicatorValue Indicator { get; }
}