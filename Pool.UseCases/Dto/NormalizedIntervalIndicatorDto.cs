using Pool.Entities.Models;

namespace Pool.UseCases.Dto;

internal sealed class NormalizedIntervalIndicatorDto
{
	public NormalizedIntervalIndicatorDto(Interval interval, double? value, double? normalizedValue)
	{
		Interval = interval;
		Value = value;
		NormalizedValue = normalizedValue;
	}

	public Interval Interval { get; }
	public double? Value { get; }
	public double? NormalizedValue { get; }
}