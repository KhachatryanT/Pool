using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Pool.Entities.Enums;
using Pool.Entities.Models;
using Pool.Infrastructure.Interfaces.DataAccess;
using Pool.UseCases.Dto;
using Pool.UseCases.Services.Interfaces;
using Pool.UseCases.Utils;

namespace Pool.UseCases.Handlers.Devices.Queries.GetDeviceHistory;

[UsedImplicitly]
internal sealed class GetDeviceHistoryQueryHandler : IQueryHandler<GetDeviceHistoryQuery, GetDeviceHistoryQueryResult>
{
	private readonly IFractionExtractorFactory _fractionExtractorFactory;
	private readonly IDbContext _dbContext;

	public GetDeviceHistoryQueryHandler(IFractionExtractorFactory fractionExtractorFactory,
		IDbContext dbContext)
	{
		_fractionExtractorFactory = fractionExtractorFactory;
		_dbContext = dbContext;
	}

	public async Task<GetDeviceHistoryQueryResult> Handle(GetDeviceHistoryQuery request,
		CancellationToken cancellationToken)
	{
		var items = new Dictionary<Interval, List<DeviceIndicatorValue>>();
		foreach (var type in request.Types)
		{
			var dto = await GetIntervalIndicatorsForType(request.PoolAlias,
				request.FractionType,
				request.StartDate,
				request.EndDate,
				type,
				cancellationToken);
			
			foreach (var indicatorsInGroup in dto.GroupBy(x => x.Interval))
			{
				if(!items.TryGetValue(indicatorsInGroup.Key, out var indicatorValues))
				{
					indicatorValues = new List<DeviceIndicatorValue>();
					items.Add(indicatorsInGroup.Key, indicatorValues);
				}
				indicatorValues.AddRange(indicatorsInGroup
					.Select(x => new DeviceIndicatorValue(type, x.Value)));
			}
		}

		return new GetDeviceHistoryQueryResult(items.Select(x => new IndicatorsInInterval(x.Key, x.Value)));
	}

	private async Task<IEnumerable<IntervalIndicatorDto>> GetIntervalIndicatorsForType(string poolAlias,
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
		var precision = DevicesHelpers.DevicePrecision(type);

		return extractor.Extract(plainHistory, startDate, endDate)
			.Select(item => new IntervalIndicatorDto(item.Interval, item.Value.WithPrecision(precision)));
	}
}