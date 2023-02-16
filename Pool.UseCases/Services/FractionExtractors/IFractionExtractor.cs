using Pool.Entities.Models;

namespace Pool.UseCases.Services.FractionExtractors;

public interface IFractionExtractor
{
	IEnumerable<IntervalIndicatorValue> Extract(IEnumerable<PoolIndicator> indicators,
		DateTimeOffset startDate,
		DateTimeOffset endDate);
}