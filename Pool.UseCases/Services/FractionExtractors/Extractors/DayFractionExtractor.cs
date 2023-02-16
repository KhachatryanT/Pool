using JetBrains.Annotations;
using MathNet.Numerics.Statistics;
using Pool.Entities.Models;
using Pool.Utils;

namespace Pool.UseCases.Services.FractionExtractors.Extractors;

internal sealed class DayFractionExtractor : IFractionExtractor
{
	public IEnumerable<IntervalIndicatorValue> Extract(IEnumerable<PoolIndicator> indicators,
		DateTimeOffset startDate,
		DateTimeOffset endDate)
	{
		startDate = startDate.StartOfDay();
		endDate = endDate.EndOfDay();

		var grouped = indicators
			.GroupBy(x => new IntervalIdentity(x.Date.Year, x.Date.Month, x.Date.Day),
				x => x.Value,
				(key, values) => new { Key = key, Median = values.Median() })
			.ToDictionary(x => x.Key, x => x.Median);

		while (startDate < endDate)
		{
			double? value = grouped.TryGetValue(new IntervalIdentity(startDate.Year, startDate.Month, startDate.Day),
				out var median)
				? median
				: null;

			yield return new IntervalIndicatorValue(value, startDate, startDate.EndOfDay());

			startDate = startDate.AddDays(1);
		}
	}

	private record IntervalIdentity([UsedImplicitly] int Year, int Month, int Day);
}