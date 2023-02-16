namespace Pool.Entities.Models;

/// <summary>
/// Временной интервал
/// </summary>
public sealed class Interval
{
	public Interval(DateTimeOffset startDate, DateTimeOffset endDate)
	{
		StartDate = startDate;
		EndDate = endDate;
	}

	/// <summary>
	/// Дата начала
	/// </summary>
	public DateTimeOffset StartDate { get; }

	/// <summary>
	/// Дата окончания
	/// </summary>
	public DateTimeOffset EndDate { get; }

	public override int GetHashCode() => HashCode.Combine(StartDate, EndDate);

	public override bool Equals(object? obj)
	{
		return obj is Interval interval && Equals(interval);
	}

	public bool Equals(Interval obj)
	{
		return StartDate == obj.StartDate &&
		       EndDate == obj.EndDate;
	}
}