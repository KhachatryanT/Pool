using MathNet.Numerics.Statistics;
using Pool.Entities.Enums;
using Pool.Entities.Models;
using Pool.UseCases.Services.FractionExtractors.Extractors;
using Pool.UseCases.Tests.Unit.Common;

namespace Pool.UseCases.Tests.Unit.Services.FractionExtractors.Extractors;

public sealed class DayFractionExtractorTests
{
	/// <summary>
	/// Тип фракции: день
	/// </summary>
	/// <returns>
	/// Возвращаются массив из 7 элементов (дней) с медианнымии значениями, где они есть
	/// </returns>
	[Fact]
	public void Handle_DayFractionType_Returns7Items()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		const int expectedHistoryItems = 6;
		var startDate = DateTimeOffset.Parse("01.01.2023 00:00:00 +03:00");
		var endDate = DateTimeOffset.Parse("06.01.2023 23:00:00 +03:00");
		var dbContext = TestPoolDbContext.CreateContext();

		var plainValues = dbContext.PoolIndicators
			.Where(x => x.Date >= startDate &&
			            x.Date <= endDate &&
			            x.Type == deviceType &&
			            x.PoolAlias == poolAlias)
			.ToArray();

		var expected1DayMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 00:00:00 +03:00", "02.01.2023 00:00:00 +03:00");
		var expected2DayMedian =
			GetMedianInPeriod(plainValues, "02.01.2023 00:00:00 +03:00", "03.01.2023 00:00:00 +03:00");
		var expected3DayMedian =
			GetMedianInPeriod(plainValues, "03.01.2023 00:00:00 +03:00", "04.01.2023 00:00:00 +03:00");
		var expected4DayMedian =
			GetMedianInPeriod(plainValues, "04.01.2023 00:00:00 +03:00", "05.01.2023 00:00:00 +03:00");
		var expected5DayMedian =
			GetMedianInPeriod(plainValues, "05.01.2023 00:00:00 +03:00", "06.01.2023 00:00:00 +03:00");
		var expected6DayMedian =
			GetMedianInPeriod(plainValues, "06.01.2023 00:00:00 +03:00", "07.01.2023 00:00:00 +03:00");

		// Act
		var actual = new DayFractionExtractor().Extract(plainValues, startDate, endDate)
			.OrderBy(x => x.Interval.StartDate)
			.ToArray();

		// Assert
		Assert.Equal(expectedHistoryItems, actual.Length);
		Assert.Equal(expected1DayMedian, actual[0].Value);
		Assert.Equal(expected2DayMedian, actual[1].Value);
		Assert.Equal(expected3DayMedian, actual[2].Value);
		Assert.Equal(expected4DayMedian, actual[3].Value);
		Assert.Equal(expected5DayMedian, actual[4].Value);
		Assert.Equal(expected6DayMedian, actual[5].Value);
	}

	private static double? GetMedianInPeriod(IEnumerable<PoolIndicator> history, string startDate, string endDate) =>
		NullIfNaN(history
			.Where(x => x.Date >= DateTimeOffset.Parse(startDate) && x.Date < DateTimeOffset.Parse(endDate))
			.Select(x => x.Value)
			.Median());

	private static double? NullIfNaN(double value) => double.IsNaN(value) ? null : value;
}