using MathNet.Numerics.Statistics;
using Pool.Entities.Enums;
using Pool.Entities.Models;
using Pool.UseCases.Services.FractionExtractors.Extractors;
using Pool.UseCases.Tests.Unit.Common;

namespace Pool.UseCases.Tests.Unit.Services.FractionExtractors.Extractors;

public sealed class MonthFractionExtractorTests
{
	/// <summary>
	/// Тип фракции: месяц
	/// </summary>
	/// <returns>
	/// Возвращается массив из 6 элементов (месяцев) с медианными значениями, где они есть
	/// </returns>
	[Fact]
	public void Handle_MonthFractionType_Returns6Items()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		const int expectedHistoryItems = 6;
		var startDate = DateTimeOffset.Parse("01.01.2023 00:00:00 +03:00");
		var endDate = DateTimeOffset.Parse("12.06.2023 00:00:00 +03:00");
		var dbContext = TestPoolDbContext.CreateContext();

		var plainValues = dbContext.PoolIndicators
			.Where(x => x.Date >= startDate &&
			            x.Date <= endDate &&
			            x.Type == deviceType &&
			            x.PoolAlias == poolAlias)
			.ToArray();

		var expected1MonthMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 00:00:00 +03:00", "01.02.2023 00:00:00 +03:00");
		var expected2MonthMedian =
			GetMedianInPeriod(plainValues, "01.02.2023 00:00:00 +03:00", "01.03.2023 00:00:00 +03:00");
		var expected3MonthMedian =
			GetMedianInPeriod(plainValues, "01.03.2023 00:00:00 +03:00", "01.04.2023 00:00:00 +03:00");
		var expected4MonthMedian =
			GetMedianInPeriod(plainValues, "01.04.2023 00:00:00 +03:00", "01.05.2023 00:00:00 +03:00");
		var expected5MonthMedian =
			GetMedianInPeriod(plainValues, "01.05.2023 00:00:00 +03:00", "01.06.2023 00:00:00 +03:00");
		var expected6MonthMedian =
			GetMedianInPeriod(plainValues, "01.06.2023 00:00:00 +03:00", "01.07.2023 00:00:00 +03:00");

		// Act
		var actual = new MonthFractionExtractor().Extract(plainValues, startDate, endDate)
			.OrderBy(x => x.Interval.StartDate)
			.ToArray();

		// Assert
		Assert.Equal(expectedHistoryItems, actual.Length);
		Assert.Equal(expected1MonthMedian, actual[0].Value);
		Assert.Equal(expected2MonthMedian, actual[1].Value);
		Assert.Equal(expected3MonthMedian, actual[2].Value);
		Assert.Equal(expected4MonthMedian, actual[3].Value);
		Assert.Equal(expected5MonthMedian, actual[4].Value);
		Assert.Equal(expected6MonthMedian, actual[5].Value);
	}

	private static double? GetMedianInPeriod(IEnumerable<PoolIndicator> history, string startDate, string endDate) =>
		NullIfNaN(history
			.Where(x => x.Date >= DateTimeOffset.Parse(startDate) && x.Date < DateTimeOffset.Parse(endDate))
			.Select(x => x.Value)
			.Median());

	private static double? NullIfNaN(double value) => double.IsNaN(value) ? null : value;
}