using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Pool.Entities.Models;
using Pool.Infrastructure.Interfaces.DataAccess;
using Pool.Infrastructure.Interfaces.Services;
using Quartz;

namespace Pool.Infrastructure.Implementation.BackgroundJobs;

[DisallowConcurrentExecution]
[UsedImplicitly]
public sealed class MonitoringJob : IJob
{
	private readonly ILogger<MonitoringJob> _logger;
	private readonly IPoolService _poolService;
	private readonly IIndicatorService _indicatorService;
	private readonly IDbContext _dbContext;

	public MonitoringJob(ILogger<MonitoringJob> logger,
		IPoolService poolService,
		IIndicatorService indicatorService,
		IDbContext dbContext)
	{
		_logger = logger;
		_poolService = poolService;
		_indicatorService = indicatorService;
		_dbContext = dbContext;
	}

	public async Task Execute(IJobExecutionContext context)
	{
		_logger.LogTrace("Получаем показатели");
		var pools = await _poolService.GetPoolsAsync(context.CancellationToken);
		foreach (var pool in pools)
		{
			var devices = await _indicatorService.GetDevicesCurrentValuesAsync(pool.Alias, context.CancellationToken);
			var entities = devices.Select(x => new PoolIndicator
			{
				PoolAlias = pool.Alias,
				ControllerCode = x.Controller,
				Date = x.Device.Indicator.Date,
				Type = x.Device.Type,
				Value = x.Device.Indicator.Value
			});
			_dbContext.PoolIndicators.AddRange(entities);
			await _dbContext.SaveChangesAsync(context.CancellationToken);
		}

		_logger.LogTrace("Показатели сохранены");
	}
}