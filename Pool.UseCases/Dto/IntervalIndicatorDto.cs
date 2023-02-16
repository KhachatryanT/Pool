using Pool.Entities.Models;

namespace Pool.UseCases.Dto;

internal sealed class IntervalIndicatorDto
{
	public IntervalIndicatorDto(Interval interval, double? value)
	{
		Interval = interval;
		Value = value;
	}

	public Interval Interval { get; }
	public double? Value { get; }
}