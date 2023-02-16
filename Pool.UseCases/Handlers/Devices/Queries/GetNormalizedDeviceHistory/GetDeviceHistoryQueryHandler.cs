using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Pool.Entities.Enums;
using Pool.Entities.Models;
using Pool.Infrastructure.Interfaces.DataAccess;
using Pool.UseCases.Dto;
using Pool.UseCases.Services.Interfaces;
using Pool.UseCases.Utils;

namespace Pool.UseCases.Handlers.Devices.Queries.GetNormalizedDeviceHistory;

[UsedImplicitly]
internal sealed class
	GetDeviceHistoryQueryHandler : IQueryHandler<GetNormalizedDeviceHistoryQuery, GetNormalizedDeviceHistoryQueryResult>
{
	private readonly IFractionExtractorFactory _fractionExtractorFactory;
	private readonly IDbContext _dbContext;

	public GetDeviceHistoryQueryHandler(IFractionExtractorFactory fractionExtractorFactory,
		IDbContext dbContext)
	{
		_fractionExtractorFactory = fractionExtractorFactory;
		_dbContext = dbContext;
	}

	public async Task<GetNormalizedDeviceHistoryQueryResult> Handle(GetNormalizedDeviceHistoryQuery request,
		CancellationToken cancellationToken)
	{
		var scales = new List<NormalizationScale>();
		var items = new Dictionary<Interval, List<NormalizedDeviceIndicatorValue>>();

		foreach (var type in request.Types)
		{
			var dto = await GetIndicatorsSummary(request.PoolAlias,
				request.FractionType,
				request.StartDate,
				request.EndDate,
				type,
				cancellationToken);

			scales.Add(new NormalizationScale(type, dto.Scale));

			foreach (var indicatorsInGroup in dto.Items.GroupBy(x => x.Interval))
			{
				if(!items.TryGetValue(indicatorsInGroup.Key, out var indicatorValues))
				{
					indicatorValues = new List<NormalizedDeviceIndicatorValue>();
					items.Add(indicatorsInGroup.Key, indicatorValues);
				}
				indicatorValues.AddRange(indicatorsInGroup
					.Select(x => new NormalizedDeviceIndicatorValue(type, x.Value, x.NormalizedValue)));
			}
		}

		return new GetNormalizedDeviceHistoryQueryResult(scales,
			items.Select(x => new NormalizedIndicatorsInInterval(x.Key, x.Value)));
	}

	private async Task<NormalizedIntervalIndicatorSummaryDto> GetIndicatorsSummary(
		string poolAlias,
		FractionType fractionType,
		DateTimeOffset startDate,
		DateTimeOffset endDate,
		DeviceType type,
		CancellationToken cancellationToken)
	{
		var plainHistory = await _dbContext.PoolIndicators
			.Where(x => x.PoolAlias == poolAlias &&
			            x.Type == type &&
			            x.Date >= startDate &&
			            x.Date <= endDate)
			.ToArrayAsync(cancellationToken);

		var extractor = _fractionExtractorFactory.CreateExtractor(fractionType);
		var history = extractor.Extract(plainHistory, startDate, endDate).ToArray();

		var orderOfNumber = GetOrderOfNumber((int)history.Max(x => Math.Abs(x.Value ?? 0)));
		var normalizationScale = (int)Math.Pow(10d, orderOfNumber);
		var valuePrecision = DevicesHelpers.DevicePrecision(type);
		var normalizedValuePrecision = valuePrecision + orderOfNumber;

		var items = from item in extractor.Extract(plainHistory, startDate, endDate)
			let value = item.Value.WithPrecision(valuePrecision)
			let normalizedValue = (item.Value / normalizationScale)?.WithPrecision(normalizedValuePrecision)
			select new NormalizedIntervalIndicatorDto(item.Interval, value, normalizedValue);
		
		return new NormalizedIntervalIndicatorSummaryDto(normalizationScale, items);
	}

	/// <summary>
	/// Получить порядок числа
	/// </summary>
	/// <param name="number"></param>
	/// <returns></returns>
	private static int GetOrderOfNumber(int number)
	{
		var order = 0;
		while (number > 0)
		{
			number /= 10;
			order++;
		}

		return order;
	}
}