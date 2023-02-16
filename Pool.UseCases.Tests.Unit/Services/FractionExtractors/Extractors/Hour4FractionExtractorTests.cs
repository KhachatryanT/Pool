using MathNet.Numerics.Statistics;
using Pool.Entities.Enums;
using Pool.Entities.Models;
using Pool.UseCases.Services.FractionExtractors.Extractors;
using Pool.UseCases.Tests.Unit.Common;

namespace Pool.UseCases.Tests.Unit.Services.FractionExtractors.Extractors;

public sealed class Hour4FractionExtractorTests
{
	/// <summary>
	/// Тип фракции: 4 часа
	/// </summary>
	/// <returns>
	/// Возвращаются массив из 18 элементов (4-x часовых интервалов),
	/// отражающих 3-х днейвный интервал с медианнымии значениями, где они есть
	/// </returns>
	[Fact]
	public void Handle_Hour4FractionType3DaysPeriod_Returns18Items()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		const int expectedHistoryItems = 18;
		var startDate = DateTimeOffset.Parse("01.01.2023 00:00:00 +03:00");
		var endDate = DateTimeOffset.Parse("03.01.2023 23:59:00 +03:00");
		var dbContext = TestPoolDbContext.CreateContext();
		var plainValues = dbContext.PoolIndicators
			.Where(x => x.Date >= startDate &&
			            x.Date <= endDate &&
			            x.Type == deviceType &&
			            x.PoolAlias == poolAlias)
			.ToArray();
		
		// Act
		var actual = new Hour4FractionExtractor().Extract(plainValues, startDate, endDate)
			.OrderBy(x => x.Interval.StartDate)
			.ToArray();
		
		// Assert
		Assert.Equal(expectedHistoryItems, actual.Length);
	}

	/// <summary>
	/// Тип фракции: 4 часа
	/// </summary>
	/// <returns>
	/// Возвращаются массив из 6 элементов (4-х часовых интервалов) с медианнымии значениями, где они есть
	/// </returns>
	[Fact]
	public void Handle_Hour4FractionType_Returns6Items()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		const int expectedHistoryItems = 6;
		var startDate = DateTimeOffset.Parse("01.01.2023 00:00:00 +03:00");
		var endDate = DateTimeOffset.Parse("01.01.2023 23:00:00 +03:00");
		var dbContext = TestPoolDbContext.CreateContext();

		var plainValues = dbContext.PoolIndicators
			.Where(x => x.Date >= startDate &&
			            x.Date <= endDate &&
			            x.Type == deviceType &&
			            x.PoolAlias == poolAlias)
			.ToArray();

		var expected0HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 00:00:00 +03:00", "01.01.2023 04:00:00 +03:00");
		var expected1HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 04:00:00 +03:00", "01.01.2023 08:00:00 +03:00");
		var expected2HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 08:00:00 +03:00", "01.01.2023 12:00:00 +03:00");
		var expected3HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 12:00:00 +03:00", "01.01.2023 16:00:00 +03:00");
		var expected4HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 16:00:00 +03:00", "01.01.2023 20:00:00 +03:00");
		var expected5HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 20:00:00 +03:00", "02.01.2023 00:00:00 +03:00");

		// Act
		var actual = new Hour4FractionExtractor().Extract(plainValues, startDate, endDate)
			.OrderBy(x => x.Interval.StartDate)
			.ToArray();

		// Assert
		Assert.Equal(expectedHistoryItems, actual.Length);
		Assert.Equal(expected0HourMedian, actual[0].Value);
		Assert.Equal(expected1HourMedian, actual[1].Value);
		Assert.Equal(expected2HourMedian, actual[2].Value);
		Assert.Equal(expected3HourMedian, actual[3].Value);
		Assert.Equal(expected4HourMedian, actual[4].Value);
		Assert.Equal(expected5HourMedian, actual[5].Value);
	}

	private static double? GetMedianInPeriod(IEnumerable<PoolIndicator> history, string startDate, string endDate) =>
		NullIfNaN(history
			.Where(x => x.Date >= DateTimeOffset.Parse(startDate) && x.Date < DateTimeOffset.Parse(endDate))
			.Select(x => x.Value)
			.Median());

	private static double? NullIfNaN(double value) => double.IsNaN(value) ? null : value;
}