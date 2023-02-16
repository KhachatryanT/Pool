namespace Pool.Utils.Tests;

public class DateTimeExtensionsTests
{
	public static IEnumerable<object[]> UnixTime_TestData()
	{
		yield return new object[] { new TestTime(DateTimeOffset.Parse("02.01.1970 00:00:00 +00:00"), 0, 0, 1) };
		yield return new object[] { new TestTime(DateTimeOffset.Parse("04.01.1970 00:00:00 +00:00"), 0, 0, 3) };
		yield return new object[] { new TestTime(DateTimeOffset.Parse("05.01.1970 00:00:00 +00:00"), 0, 1, 4) };
		yield return new object[] { new TestTime(DateTimeOffset.Parse("01.02.1970 00:00:00 +00:00"), 1, 4, 31) };
		yield return new object[] { new TestTime(DateTimeOffset.Parse("16.06.1970 00:00:00 +00:00"), 5, 24, 166) };
		yield return new object[] { new TestTime(DateTimeOffset.Parse("01.01.1971 00:00:00 +00:00"), 12, 52, 365) };
		yield return new object[] { new TestTime(DateTimeOffset.Parse("03.04.1975 00:00:00 +00:00"), 63, 274, 1918) };
	}

	[Theory]
	[MemberData(nameof(UnixTime_TestData))]
	public void ToUnixTimeMonthTest(TestTime test)
	{
		// Arrange
		var expected = test.ExpectedMonthsFromEpoch;
		// Act
		var actual = test.Date.ToUnixTimeMonth();
		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[MemberData(nameof(UnixTime_TestData))]
	public void ToUnixTimeWeekTest(TestTime test)
	{
		// Arrange
		var expected = test.ExpectedWeeksFromEpoch;
		// Act
		var actual = test.Date.ToUnixTimeWeek();
		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[MemberData(nameof(UnixTime_TestData))]
	public void ToUnixTimeDayTest(TestTime test)
	{
		// Arrange
		var expected = test.ExpectedDaysFromEpoch;
		// Act
		var actual = test.Date.ToUnixTimeDay();
		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void AddWeeks_Add2Weeks_Test()
	{
		// Arrange
		var initialDate = DateTimeOffset.Parse("02.01.2023 01:00:00 +03:00");
		var expectedDate = DateTimeOffset.Parse("16.01.2023 01:00:00 +03:00");
		// Act
		var actual = initialDate.AddWeeks(2);
		// Assert
		Assert.Equal(expectedDate, actual);
	}

	[Fact]
	public void StartOfWeekTest()
	{
		// Arrange
		var initialDate = DateTimeOffset.Parse("05.01.2023 04:01:01.0400000 +03:00");
		var expectedDate = DateTimeOffset.Parse("02.01.2023 00:00:00 +03:00");
		// Act
		var actual = initialDate.StartOfWeek();
		// Assert
		Assert.Equal(expectedDate, actual);
	}

	[Fact]
	public void EndOfWeekTest()
	{
		// Arrange
		var initialDate = DateTimeOffset.Parse("02.01.2023 01:01:01.0000000 +03:00");
		var expectedDate = DateTimeOffset.Parse("08.01.2023 23:59:59.9999999 +03:00");
		// Act
		var actual = initialDate.EndOfWeek();
		// Assert
		Assert.Equal(expectedDate, actual);
	}

	[Fact]
	public void StartOfDayTest()
	{
		// Arrange
		var initialDate = DateTimeOffset.Parse("02.01.2023 21:14:01.0040000 +03:00");
		var expectedDate = DateTimeOffset.Parse("02.01.2023 00:00:00.0000000 +03:00");
		// Act
		var actual = initialDate.StartOfDay();
		// Assert
		Assert.Equal(expectedDate, actual);
	}

	[Fact]
	public void EndOfDayTest()
	{
		// Arrange
		var initialDate = DateTimeOffset.Parse("02.01.2023 11:14:01.0040000 +03:00");
		var expectedDate = DateTimeOffset.Parse("02.01.2023 23:59:59.9999999 +03:00");
		// Act
		var actual = initialDate.EndOfDay();
		// Assert
		Assert.Equal(expectedDate, actual);
	}

	public record TestTime(DateTimeOffset Date,
		int ExpectedMonthsFromEpoch,
		int ExpectedWeeksFromEpoch,
		int ExpectedDaysFromEpoch);
}