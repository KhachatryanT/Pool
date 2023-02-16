using MathNet.Numerics.Statistics;
using Pool.Entities.Enums;
using Pool.Entities.Models;
using Pool.UseCases.Services.FractionExtractors.Extractors;
using Pool.UseCases.Tests.Unit.Common;

namespace Pool.UseCases.Tests.Unit.Services.FractionExtractors.Extractors;

public sealed class WeekFractionExtractorTests
{
	/// <summary>
	/// Тип фракции: неделя
	/// </summary>
	/// <returns>
	/// Возвращаются массив из 4 элементов (недель) с медианнымии значениями, где они есть
	/// </returns>
	[Fact]
	public void Handle_WeekFractionType_Returns4Items()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		const int expectedHistoryItems = 4;
		var startDate = DateTimeOffset.Parse("02.01.2023 00:00:00 +03:00");
		var endDate = DateTimeOffset.Parse("30.01.2023 00:00:00 +03:00");
		var dbContext = TestPoolDbContext.CreateContext();

		var plainValues = dbContext.PoolIndicators
			.Where(x => x.Date >= startDate &&
			            x.Date <= endDate &&
			            x.Type == deviceType &&
			            x.PoolAlias == poolAlias)
			.ToArray();
		var expected1WeekMedian =
			GetMedianInPeriod(plainValues, "02.01.2023 00:00:00 +03:00", "09.01.2023 00:00:00 +03:00");
		var expected2WeekMedian =
			GetMedianInPeriod(plainValues, "09.01.2023 00:00:00 +03:00", "16.01.2023 00:00:00 +03:00");
		var expected3WeekMedian =
			GetMedianInPeriod(plainValues, "16.01.2023 00:00:00 +03:00", "23.01.2023 00:00:00 +03:00");
		var expected4WeekMedian =
			GetMedianInPeriod(plainValues, "23.01.2023 00:00:00 +03:00", "30.01.2023 00:00:00 +03:00");

		// Act
		var actual = new WeekFractionExtractor().Extract(plainValues, startDate, endDate)
			.OrderBy(x => x.Interval.StartDate)
			.ToArray();

		// Assert
		Assert.Equal(expectedHistoryItems, actual.Length);
		Assert.Equal(expected1WeekMedian, actual[0].Value);
		Assert.Equal(expected2WeekMedian, actual[1].Value);
		Assert.Equal(expected3WeekMedian, actual[2].Value);
		Assert.Equal(expected4WeekMedian, actual[3].Value);
	}

	/// <summary>
	/// Сценарий:
	/// Тип фракции: неделя
	/// Проверка получения корретных данных при передаче интеравала, где
	/// дата начала - это последние недели уходящего года,
	/// а дата окончания - первые недели нового года
	/// </summary>
	[Fact]
	public void Handle_WeekFractionTypeBetweenEndOfYearAndStartOfNewYear_Returns5Items()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		const int expectedHistoryItems = 5;
		var startDate = DateTimeOffset.Parse("12.12.2022 00:00:00 +03:00");
		var endDate = DateTimeOffset.Parse("16.01.2023 00:00:00 +03:00");
		var dbContext = TestPoolDbContext.CreateContext();

		var plainValues = dbContext.PoolIndicators
			.Where(x => x.Date >= startDate &&
			            x.Date <= endDate &&
			            x.Type == deviceType &&
			            x.PoolAlias == poolAlias)
			.ToArray();
		var expected1WeekMedian =
			GetMedianInPeriod(plainValues, "12.12.2022 00:00:00 +03:00", "19.12.2022 00:00:00 +03:00");
		var expected2WeekMedian =
			GetMedianInPeriod(plainValues, "19.12.2022 00:00:00 +03:00", "26.12.2022 00:00:00 +03:00");
		var expected3WeekMedian =
			GetMedianInPeriod(plainValues, "26.12.2022 00:00:00 +03:00", "02.01.2023 00:00:00 +03:00");
		var expected4WeekMedian =
			GetMedianInPeriod(plainValues, "02.01.2023 00:00:00 +03:00", "09.01.2023 00:00:00 +03:00");
		var expected5WeekMedian =
			GetMedianInPeriod(plainValues, "09.01.2023 00:00:00 +03:00", "16.01.2023 00:00:00 +03:00");

		// Act
		var actual = new WeekFractionExtractor().Extract(plainValues, startDate, endDate)
			.OrderBy(x => x.Interval.StartDate)
			.ToArray();

		// Assert
		Assert.Equal(expectedHistoryItems, actual.Length);
		Assert.Equal(expected1WeekMedian, actual[0].Value);
		Assert.Equal(expected2WeekMedian, actual[1].Value);
		Assert.Equal(expected3WeekMedian, actual[2].Value);
		Assert.Equal(expected4WeekMedian, actual[3].Value);
		Assert.Equal(expected5WeekMedian, actual[4].Value);
	}

	private static double? GetMedianInPeriod(IEnumerable<PoolIndicator> history, string startDate, string endDate) =>
		NullIfNaN(history
			.Where(x => x.Date >= DateTimeOffset.Parse(startDate) && x.Date < DateTimeOffset.Parse(endDate))
			.Select(x => x.Value)
			.Median());

	private static double? NullIfNaN(double value) => double.IsNaN(value) ? null : value;
}