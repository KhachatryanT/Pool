using Pool.UseCases.Services.FractionValidators.Validators;

namespace Pool.UseCases.Tests.Unit.Services.FractionValidators.Validators;

public sealed class WeekFractionValidatorTests
{
	public static IEnumerable<object[]> NotMonday_TestData()
	{
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 00:00:00.0010000 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 00:00:01 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 00:01:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 01:00:00 +03:00") };

		yield return new object[] { DateTimeOffset.Parse("10.01.2023 00:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("11.01.2023 00:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("12.01.2023 00:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("13.01.2023 00:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("14.01.2023 00:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("15.01.2023 00:00:00 +03:00") };
	}


	[Fact]
	public void IsValid_Monday_ReturnsTrue()
	{
		// Arrange
		var date = DateTimeOffset.Parse("09.01.2023 00:00:00 +03:00");
		// Act
		var actual = new WeekFractionValidator().IsValid(date);
		// Assert
		Assert.True(actual);
	}

	[Theory]
	[MemberData(nameof(NotMonday_TestData))]
	public void IsValid_NotMonday_ReturnsFalse(DateTimeOffset date)
	{
		// Arrange
		// Act
		var actual = new WeekFractionValidator().IsValid(date);
		// Assert
		Assert.False(actual);
	}
}