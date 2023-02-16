using MathNet.Numerics.Statistics;
using Pool.Entities.Models;
using Pool.Utils;

namespace Pool.UseCases.Services.FractionExtractors.Extractors;

internal sealed class WeekFractionExtractor : IFractionExtractor
{
	public IEnumerable<IntervalIndicatorValue> Extract(IEnumerable<PoolIndicator> indicators,
		DateTimeOffset startDate,
		DateTimeOffset endDate)
	{
		startDate = startDate.StartOfWeek();
		var endDateEpochWeek = endDate.EndOfWeek().ToUnixTimeWeek();
		
		var grouped = indicators
			.GroupBy(x => x.Date.ToUnixTimeWeek(),
				x => x.Value,
				(key, values) => new { Key = key, Median = values.Median() })
			.ToDictionary(x => x.Key, x => x.Median);

		for (var epochWeek = startDate.ToUnixTimeWeek(); epochWeek < endDateEpochWeek; epochWeek++)
		{
			double? value = grouped.TryGetValue(epochWeek, out var median) ? median : null;
			yield return new IntervalIndicatorValue(value, startDate, startDate.EndOfWeek());

			startDate = startDate.AddWeeks(1);
		}
	}
}