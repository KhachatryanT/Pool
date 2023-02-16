using JetBrains.Annotations;
using MathNet.Numerics.Statistics;
using Pool.Entities.Models;
using Pool.Utils;

namespace Pool.UseCases.Services.FractionExtractors.Extractors;

internal sealed class MonthFractionExtractor : IFractionExtractor
{
	public IEnumerable<IntervalIndicatorValue> Extract(IEnumerable<PoolIndicator> indicators,
		DateTimeOffset startDate,
		DateTimeOffset endDate)
	{
		startDate = startDate.StartOfMonth();
		endDate = endDate.EndOfMonth();

		var grouped = indicators
			.GroupBy(x => new IntervalIdentity(x.Date.Year, x.Date.Month),
				x => x.Value,
				(key, values) => new { Key = key, Median = values.Median() })
			.ToDictionary(x => x.Key, x => x.Median);

		while (startDate < endDate)
		{
			double? value = grouped.TryGetValue(new IntervalIdentity(startDate.Year, startDate.Month), out var median)
				? median
				: null;
			
			yield return new IntervalIndicatorValue(value, startDate, startDate.EndOfMonth());
			
			startDate = startDate.AddMonths(1);
		}
	}
	
	private record IntervalIdentity([UsedImplicitly] int Year, int Month);
}