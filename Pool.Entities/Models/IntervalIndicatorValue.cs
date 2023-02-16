namespace Pool.Entities.Models;

/// <summary>
/// Значение индикатора в интервале
/// </summary>
public sealed class IntervalIndicatorValue
{
	public IntervalIndicatorValue(double? value, DateTimeOffset startDate, DateTimeOffset endDate)
		: this(value, new Interval(startDate, endDate))
	{
	}

	public IntervalIndicatorValue(double? value, Interval interval)
	{
		Value = value;
		Interval = interval;
	}

	/// <summary>
	/// Временной интервал
	/// </summary>
	public Interval Interval { get; }

	/// <summary>
	/// Значение
	/// </summary>
	public double? Value { get; }
}