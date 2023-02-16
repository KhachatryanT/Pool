using Pool.Entities.Enums;
using Pool.UseCases.Services.FractionExtractors.Extractors;
using Pool.UseCases.Tests.Unit.Common;

namespace Pool.UseCases.Tests.Unit.Services.FractionExtractors.Extractors;

public sealed class NoneFractionExtractorTests
{
	/// <summary>
	/// Тип фракции: None
	/// </summary>
	/// <returns>
	/// Возвращаются массив из всех имеющихся медианнымых значений
	/// </returns>
	[Fact]
	public void Handle_NoneFractionType_ReturnsAllExistingItems()
	{
		// Arrange
		const string poolAlias = "pool 1";
		const DeviceType deviceType = DeviceType.Ph;
		var startDate = DateTimeOffset.Parse("01.01.2023 00:00:00 +03:00");
		var endDate = DateTimeOffset.Parse("07.01.2023 00:00:00 +03:00");
		var dbContext = TestPoolDbContext.CreateContext();

		var expectedValues = dbContext.PoolIndicators
			.Where(x => x.Date >= startDate &&
			            x.Date <= endDate &&
			            x.Type == deviceType &&
			            x.PoolAlias == poolAlias)
			.ToArray();

		// Act
		var actual = new NoneFractionExtractor().Extract(expectedValues, startDate, endDate)
			.OrderBy(x => x.Interval.StartDate)
			.ToArray();

		// Assert
		Assert.Equal(expectedValues.Length, actual.Length);
		foreach (var expectedItem in expectedValues)
		{
			Assert.True(actual.Any(x => x.Value.Equals(expectedItem.Value) &&
			                            x.Interval.StartDate == expectedItem.Date),
				$"Indicator of date {expectedItem.Date} is missing");
		}
	}
}