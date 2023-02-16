namespace Pool.Entities.Models;

/// <summary>
/// Значение показателя в момент времени
/// </summary>
public sealed class IndicatorValue
{
	public IndicatorValue(DateTimeOffset date, double value, IndicatorDetailsBase details)
	{
		Date = date;
		Value = value;
		Details = details;
	}

	public void SetPrecision(int precision)
	{
		Value = Math.Round(Value, precision);
	}

	public DateTimeOffset Date { get; }
	public double Value { get; private set; }
	public IndicatorDetailsBase Details { get; }
}