namespace Pool.Entities.Models;

public sealed class NormalizedIndicatorsInInterval
{
	public NormalizedIndicatorsInInterval(Interval interval, IEnumerable<NormalizedDeviceIndicatorValue> indicators)
	{
		Interval = interval;
		Indicators = indicators;
	}

	public Interval Interval { get; }
	public IEnumerable<NormalizedDeviceIndicatorValue> Indicators { get; }
}