using Pool.Entities.Models;

namespace Pool.UseCases.Services.FractionExtractors.Extractors;

internal sealed class NoneFractionExtractor : IFractionExtractor
{
	public IEnumerable<IntervalIndicatorValue> Extract(IEnumerable<PoolIndicator> indicators,
		DateTimeOffset startDate,
		DateTimeOffset endDate)
	{
		return indicators.Select(x =>
			new IntervalIndicatorValue(x.Value, x.Date, x.Date));
	}
}