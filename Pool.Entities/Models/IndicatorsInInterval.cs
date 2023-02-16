namespace Pool.Entities.Models;

public sealed class IndicatorsInInterval
{
	public IndicatorsInInterval(Interval interval, IEnumerable<DeviceIndicatorValue> indicators)
	{
		Interval = interval;
		Indicators = indicators;
	}

	public Interval Interval { get; }
	public IEnumerable<DeviceIndicatorValue> Indicators { get; }
}