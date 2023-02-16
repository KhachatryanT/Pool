using Pool.UseCases.Services.FractionValidators.Validators;

namespace Pool.UseCases.Tests.Unit.Services.FractionValidators.Validators;

public sealed class Hour4FractionValidatorTests
{
	public static IEnumerable<object[]> NotMod4Hour_TestData()
	{
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 00:00:00.0010000 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 00:00:01 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 00:01:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 01:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("10.01.2023 03:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("11.01.2023 02:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("12.01.2023 10:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("13.01.2023 13:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("14.01.2023 23:00:00 +03:00") };
	}
	
	public static IEnumerable<object[]> Mod4Hour_TestData()
	{
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 00:00:00.0000000 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 04:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 08:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("09.01.2023 12:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("10.01.2023 16:00:00 +03:00") };
		yield return new object[] { DateTimeOffset.Parse("11.01.2023 20:00:00 +03:00") };
	}
	
	[Theory]
	[MemberData(nameof(Mod4Hour_TestData))]
	public void IsValid_Mod4_ReturnsTrue(DateTimeOffset date)
	{
		// Arrange
		// Act
		var actual = new Hour4FractionValidator().IsValid(date);
		// Assert
		Assert.True(actual);
	}
	
	[Theory]
	[MemberData(nameof(NotMod4Hour_TestData))]
	public void IsValid_NotMod4_ReturnsFalse(DateTimeOffset date)
	{
		// Arrange
		// Act
		var actual = new Hour4FractionValidator().IsValid(date);
		// Assert
		Assert.False(actual);
	}
	
}