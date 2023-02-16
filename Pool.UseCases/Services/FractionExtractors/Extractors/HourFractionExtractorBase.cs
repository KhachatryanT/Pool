using JetBrains.Annotations;
using MathNet.Numerics.Statistics;
using Pool.Entities.Models;
using Pool.Utils;

namespace Pool.UseCases.Services.FractionExtractors.Extractors;

internal abstract class HourFractionExtractorBase : IFractionExtractor
{
	/// <summary>
	/// Тип группировки по часам
	/// </summary>
	/// <remarks>
	/// Например "группировка по 4 часа"
	/// </remarks>
	protected abstract int HourFraction { get; }

	public IEnumerable<IntervalIndicatorValue> Extract(IEnumerable<PoolIndicator> indicators, 
		DateTimeOffset startDate,
		DateTimeOffset endDate)
	{
		startDate = startDate.StartOfHour();
		endDate = endDate.EndOfHour();

		var grouped = indicators
			.GroupBy(x => new IntervalIdentity(x.Date.Year, x.Date.Month, x.Date.Day, x.Date.Hour / HourFraction),
				x => x.Value,
				(key, values) => new { Key = key, Median = values.Median() })
			.ToDictionary(x => x.Key, x => x.Median);

		while (startDate < endDate)
		{
			double? value =
				grouped.TryGetValue(
					new IntervalIdentity(startDate.Year, startDate.Month, startDate.Day, startDate.Hour / HourFraction),
					out var median)
					? median
					: null;
			yield return new IntervalIndicatorValue(value, startDate, startDate.AddHours(HourFraction).AddTicks(-1));

			startDate = startDate.AddHours(HourFraction);
		}
	}

	private record IntervalIdentity([UsedImplicitly] int Year, int Month, int Day, int Hour);
}