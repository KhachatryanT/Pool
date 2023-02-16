using Pool.Entities.Enums;
using Pool.UseCases.Services.FractionExtractors;
using Pool.UseCases.Services.FractionExtractors.Extractors;
using Pool.UseCases.Services.Interfaces;

namespace Pool.UseCases.Services;

internal sealed class FractionExtractorFactory : IFractionExtractorFactory
{
	public IFractionExtractor CreateExtractor(FractionType fractionType)
		=> fractionType switch
		{
			FractionType.None => new NoneFractionExtractor(),
			FractionType.Hour => new Hour1FractionExtractor(),
			FractionType.Hour4 => new Hour4FractionExtractor(),
			FractionType.Day => new DayFractionExtractor(),
			FractionType.Week => new WeekFractionExtractor(),
			FractionType.Month => new MonthFractionExtractor(),
			_ => throw new ArgumentOutOfRangeException(nameof(fractionType), fractionType, null)
		};
}