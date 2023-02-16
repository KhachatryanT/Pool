using MathNet.Numerics.Statistics;
using Pool.Entities.Enums;
using Pool.Entities.Models;
using Pool.UseCases.Services.FractionExtractors.Extractors;
using Pool.UseCases.Tests.Unit.Common;

namespace Pool.UseCases.Tests.Unit.Services.FractionExtractors.Extractors;

public sealed class HourFractionExtractorTests
{
	/// <summary>
	/// Тип фракции: час
	/// </summary>
	/// <returns>
	/// Возвращаются массив из 72 элементов (часов),
	/// отражающих 3-х днейвный интервал с медианнымии значениями, где они есть
	/// </returns>
	[Fact]
	public void Handle_HourFractionType3DaysPeriod_Returns72Items()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		const int expectedHistoryItems = 72;
		var startDate = DateTimeOffset.Parse("01.01.2023 00:00:00 +03:00");
		var endDate = DateTimeOffset.Parse("03.01.2023 23:59:59 +03:00");
		var dbContext = TestPoolDbContext.CreateContext();

		var plainValues = dbContext.PoolIndicators
			.Where(x => x.Date >= startDate &&
			            x.Date <= endDate &&
			            x.Type == deviceType &&
			            x.PoolAlias == poolAlias)
			.ToArray();

		// Act
		var actual = new Hour1FractionExtractor().Extract(plainValues, startDate, endDate)
			.OrderBy(x => x.Interval.StartDate)
			.ToArray();

		// Assert
		Assert.Equal(expectedHistoryItems, actual.Length);
	}

	/// <summary>
	/// Тип фракции: час
	/// Интервал 2 часа
	/// </summary>
	/// <returns>
	/// Возвращаются массив из 2 элементов (часов) с медианнымии значениями, где они есть
	/// </returns>
	[Fact]
	public void Handle_HourFractionType_Returns2Items()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		const int expectedHistoryItems = 2;
		var startDate = DateTimeOffset.Parse("01.01.2023 00:00:00 +03:00");
		var endDate = DateTimeOffset.Parse("01.01.2023 01:59:00 +03:00");
		var dbContext = TestPoolDbContext.CreateContext();

		var plainValues = dbContext.PoolIndicators
			.Where(x => x.Date >= startDate &&
			            x.Date <= endDate &&
			            x.Type == deviceType &&
			            x.PoolAlias == poolAlias)
			.ToArray();

		var expected0HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 00:00:00 +03:00", "01.01.2023 01:00:00 +03:00");
		var expected1HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 01:00:00 +03:00", "01.01.2023 02:00:00 +03:00");

		// Act
		var actual = new Hour1FractionExtractor().Extract(plainValues, startDate, endDate)
			.OrderBy(x => x.Interval.StartDate)
			.ToArray();

		// Assert
		Assert.Equal(expectedHistoryItems, actual.Length);
		Assert.Equal(expected0HourMedian, actual[0].Value);
		Assert.Equal(expected1HourMedian, actual[1].Value);
	}

	/// <summary>
	/// Тип фракции: час
	/// Интервал больше суток
	/// </summary>
	/// <returns>
	/// Возвращаются массив из 2 элементов (часов) с медианнымии значениями, где они есть
	/// </returns>
	[Fact]
	public void Handle_HourFractionType_Returns26Items()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		const int expectedHistoryItems = 26;
		var startDate = DateTimeOffset.Parse("01.01.2023 00:00:00 +03:00");
		var endDate = DateTimeOffset.Parse("02.01.2023 01:59:00 +03:00");
		var dbContext = TestPoolDbContext.CreateContext();

		var plainValues = dbContext.PoolIndicators
			.Where(x => x.Date >= startDate &&
			            x.Date <= endDate &&
			            x.Type == deviceType &&
			            x.PoolAlias == poolAlias)
			.ToArray();

		var expected0HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 00:00:00 +03:00", "01.01.2023 01:00:00 +03:00");
		var expected1HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 01:00:00 +03:00", "01.01.2023 02:00:00 +03:00");
		var expected2HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 02:00:00 +03:00", "01.01.2023 03:00:00 +03:00");
		var expected3HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 03:00:00 +03:00", "01.01.2023 04:00:00 +03:00");
		var expected4HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 04:00:00 +03:00", "01.01.2023 05:00:00 +03:00");
		var expected5HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 05:00:00 +03:00", "01.01.2023 06:00:00 +03:00");
		var expected6HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 06:00:00 +03:00", "01.01.2023 07:00:00 +03:00");
		var expected7HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 07:00:00 +03:00", "01.01.2023 08:00:00 +03:00");
		var expected8HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 08:00:00 +03:00", "01.01.2023 09:00:00 +03:00");
		var expected9HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 09:00:00 +03:00", "01.01.2023 10:00:00 +03:00");
		var expected10HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 10:00:00 +03:00", "01.01.2023 11:00:00 +03:00");
		var expected11HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 11:00:00 +03:00", "01.01.2023 12:00:00 +03:00");
		var expected12HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 12:00:00 +03:00", "01.01.2023 13:00:00 +03:00");
		var expected13HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 13:00:00 +03:00", "01.01.2023 14:00:00 +03:00");
		var expected14HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 14:00:00 +03:00", "01.01.2023 15:00:00 +03:00");
		var expected15HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 15:00:00 +03:00", "01.01.2023 16:00:00 +03:00");
		var expected16HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 16:00:00 +03:00", "01.01.2023 17:00:00 +03:00");
		var expected17HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 17:00:00 +03:00", "01.01.2023 18:00:00 +03:00");
		var expected18HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 18:00:00 +03:00", "01.01.2023 19:00:00 +03:00");
		var expected19HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 19:00:00 +03:00", "01.01.2023 20:00:00 +03:00");
		var expected20HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 20:00:00 +03:00", "01.01.2023 21:00:00 +03:00");
		var expected21HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 21:00:00 +03:00", "01.01.2023 22:00:00 +03:00");
		var expected22HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 22:00:00 +03:00", "01.01.2023 23:00:00 +03:00");
		var expected23HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 23:00:00 +03:00", "02.01.2023 00:00:00 +03:00");
		var expected24HourMedian =
			GetMedianInPeriod(plainValues, "02.01.2023 00:00:00 +03:00", "02.01.2023 01:00:00 +03:00");
		var expected25HourMedian =
			GetMedianInPeriod(plainValues, "02.01.2023 01:00:00 +03:00", "02.01.2023 02:00:00 +03:00");

		// Act
		var actual = new Hour1FractionExtractor().Extract(plainValues, startDate, endDate)
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
		Assert.Equal(expected6HourMedian, actual[6].Value);
		Assert.Equal(expected7HourMedian, actual[7].Value);
		Assert.Equal(expected8HourMedian, actual[8].Value);
		Assert.Equal(expected9HourMedian, actual[9].Value);
		Assert.Equal(expected10HourMedian, actual[10].Value);
		Assert.Equal(expected11HourMedian, actual[11].Value);
		Assert.Equal(expected12HourMedian, actual[12].Value);
		Assert.Equal(expected13HourMedian, actual[13].Value);
		Assert.Equal(expected14HourMedian, actual[14].Value);
		Assert.Equal(expected15HourMedian, actual[15].Value);
		Assert.Equal(expected16HourMedian, actual[16].Value);
		Assert.Equal(expected17HourMedian, actual[17].Value);
		Assert.Equal(expected18HourMedian, actual[18].Value);
		Assert.Equal(expected19HourMedian, actual[19].Value);
		Assert.Equal(expected20HourMedian, actual[20].Value);
		Assert.Equal(expected21HourMedian, actual[21].Value);
		Assert.Equal(expected22HourMedian, actual[22].Value);
		Assert.Equal(expected23HourMedian, actual[23].Value);
		Assert.Equal(expected24HourMedian, actual[24].Value);
		Assert.Equal(expected25HourMedian, actual[25].Value);
	}

	/// <summary>
	/// Тип фракции: час
	/// </summary>
	/// <returns>
	/// Возвращаются массив из 24 элементов (часов) с медианнымии значениями, где они есть
	/// </returns>
	[Fact]
	public void Handle_HourFractionType_Returns24Items()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		const int expectedHistoryItems = 24;
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
			GetMedianInPeriod(plainValues, "01.01.2023 00:00:00 +03:00", "01.01.2023 01:00:00 +03:00");
		var expected1HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 01:00:00 +03:00", "01.01.2023 02:00:00 +03:00");
		var expected2HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 02:00:00 +03:00", "01.01.2023 03:00:00 +03:00");
		var expected3HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 03:00:00 +03:00", "01.01.2023 04:00:00 +03:00");
		var expected4HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 04:00:00 +03:00", "01.01.2023 05:00:00 +03:00");
		var expected5HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 05:00:00 +03:00", "01.01.2023 06:00:00 +03:00");
		var expected6HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 06:00:00 +03:00", "01.01.2023 07:00:00 +03:00");
		var expected7HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 07:00:00 +03:00", "01.01.2023 08:00:00 +03:00");
		var expected8HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 08:00:00 +03:00", "01.01.2023 09:00:00 +03:00");
		var expected9HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 09:00:00 +03:00", "01.01.2023 10:00:00 +03:00");
		var expected10HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 10:00:00 +03:00", "01.01.2023 11:00:00 +03:00");
		var expected11HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 11:00:00 +03:00", "01.01.2023 12:00:00 +03:00");
		var expected12HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 12:00:00 +03:00", "01.01.2023 13:00:00 +03:00");
		var expected13HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 13:00:00 +03:00", "01.01.2023 14:00:00 +03:00");
		var expected14HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 14:00:00 +03:00", "01.01.2023 15:00:00 +03:00");
		var expected15HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 15:00:00 +03:00", "01.01.2023 16:00:00 +03:00");
		var expected16HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 16:00:00 +03:00", "01.01.2023 17:00:00 +03:00");
		var expected17HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 17:00:00 +03:00", "01.01.2023 18:00:00 +03:00");
		var expected18HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 18:00:00 +03:00", "01.01.2023 19:00:00 +03:00");
		var expected19HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 19:00:00 +03:00", "01.01.2023 20:00:00 +03:00");
		var expected20HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 20:00:00 +03:00", "01.01.2023 21:00:00 +03:00");
		var expected21HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 21:00:00 +03:00", "01.01.2023 22:00:00 +03:00");
		var expected22HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 22:00:00 +03:00", "01.01.2023 23:00:00 +03:00");
		var expected23HourMedian =
			GetMedianInPeriod(plainValues, "01.01.2023 23:00:00 +03:00", "02.01.2023 00:00:00 +03:00");

		// Act
		var actual = new Hour1FractionExtractor().Extract(plainValues, startDate, endDate)
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
		Assert.Equal(expected6HourMedian, actual[6].Value);
		Assert.Equal(expected7HourMedian, actual[7].Value);
		Assert.Equal(expected8HourMedian, actual[8].Value);
		Assert.Equal(expected9HourMedian, actual[9].Value);
		Assert.Equal(expected10HourMedian, actual[10].Value);
		Assert.Equal(expected11HourMedian, actual[11].Value);
		Assert.Equal(expected12HourMedian, actual[12].Value);
		Assert.Equal(expected13HourMedian, actual[13].Value);
		Assert.Equal(expected14HourMedian, actual[14].Value);
		Assert.Equal(expected15HourMedian, actual[15].Value);
		Assert.Equal(expected16HourMedian, actual[16].Value);
		Assert.Equal(expected17HourMedian, actual[17].Value);
		Assert.Equal(expected18HourMedian, actual[18].Value);
		Assert.Equal(expected19HourMedian, actual[19].Value);
		Assert.Equal(expected20HourMedian, actual[20].Value);
		Assert.Equal(expected21HourMedian, actual[21].Value);
		Assert.Equal(expected22HourMedian, actual[22].Value);
		Assert.Equal(expected23HourMedian, actual[23].Value);
	}

	private static double? GetMedianInPeriod(IEnumerable<PoolIndicator> history, string startDate, string endDate) =>
		NullIfNaN(history
			.Where(x => x.Date >= DateTimeOffset.Parse(startDate) && x.Date < DateTimeOffset.Parse(endDate))
			.Select(x => x.Value)
			.Median());

	private static double? NullIfNaN(double value) => double.IsNaN(value) ? null : value;
}