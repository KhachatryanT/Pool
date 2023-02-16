namespace Pool.Utils;

public static class DateTimeExtensions
{
	private const int MonthsInYear = 12;
	private const int DaysInWeek = 7;
	
	/// <remarks>
	/// Используется локальный offset для корректности вычисления недель 
	/// </remarks>
	private static readonly DateTimeOffset UnixEpochOffset = new(1970, 1, 1, 0, 0, 0, DateTimeOffset.Now.Offset);

	public static DateTimeOffset StartOfMonth(this DateTimeOffset date)
	{
		return new DateTimeOffset(date.Year, date.Month, 1, 0, 0, 0, date.Offset);
	}

	public static DateTimeOffset EndOfMonth(this DateTimeOffset date)
	{
		return date.StartOfMonth().AddMonths(1).AddTicks(-1);
	}

	public static int ToUnixTimeMonth(this DateTimeOffset date)
	{
		return (date.Year - UnixEpochOffset.Year) * MonthsInYear + date.Month - UnixEpochOffset.Month;
	}

	public static int ToUnixTimeWeek(this DateTimeOffset date)
	{
		// Дней от понедельника до 01.01.1970
		const int daysFromMonday = 3;
		return (date.ToUnixTimeDay() + daysFromMonday) / DaysInWeek;
	}

	public static int ToUnixTimeDay(this DateTimeOffset date)
	{
		return (date - UnixEpochOffset).Days;
	}

	public static DateTimeOffset AddWeeks(this DateTimeOffset date, double weeks)
	{
		return date.AddDays(DaysInWeek * weeks);
	}

	public static DateTimeOffset StartOfWeek(this DateTimeOffset date)
	{
		var daysToRemove = LocalDayOfWeek.Monday - ToLocalDayOfWeek(date.DayOfWeek);
		return date.AddDays(daysToRemove).Date;
	}

	public static DateTimeOffset EndOfWeek(this DateTimeOffset date)
	{
		return date.StartOfWeek().AddDays(DaysInWeek).AddTicks(-1);
	}

	public static DateTimeOffset StartOfDay(this DateTimeOffset date)
	{
		return date.Date;
	}

	public static DateTimeOffset EndOfDay(this DateTimeOffset date)
	{
		return date.StartOfDay().AddDays(1).AddTicks(-1);
	}

	public static DateTimeOffset StartOfHour(this DateTimeOffset date)
	{
		return new DateTimeOffset(date.Year, date.Month, date.Day, date.Hour, 0, 0, date.Offset);
	}
	
	public static DateTimeOffset EndOfHour(this DateTimeOffset date)
	{
		return date.StartOfHour().AddHours(1).AddTicks(-1);
	}

	private static LocalDayOfWeek ToLocalDayOfWeek(this DayOfWeek dayOfWeek) =>
		dayOfWeek switch
		{
			DayOfWeek.Monday => LocalDayOfWeek.Monday,
			DayOfWeek.Tuesday => LocalDayOfWeek.Tuesday,
			DayOfWeek.Wednesday => LocalDayOfWeek.Wednesday,
			DayOfWeek.Thursday => LocalDayOfWeek.Thursday,
			DayOfWeek.Friday => LocalDayOfWeek.Friday,
			DayOfWeek.Saturday => LocalDayOfWeek.Saturday,
			DayOfWeek.Sunday => LocalDayOfWeek.Sunday,
			_ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), dayOfWeek, null)
		};
}