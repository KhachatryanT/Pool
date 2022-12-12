using JetBrains.Annotations;
using Pool.DevicesControllers.Abstractions.Models;
using Pool.DevicesControllers.Abstractions.Services;
using Pool.Domain.Entities;
using Pool.Domain.Repositories;
using Quartz;

namespace Pool.Api.Jobs;

[DisallowConcurrentExecution]
[UsedImplicitly]
internal sealed class MonitoringJob : IJob
{
	private readonly ILogger<MonitoringJob> _logger;
	private readonly IPoolService _poolService;
	private readonly IDevicesService _devicesService;
	private readonly IDeviceHistoryRepository _deviceHistoryRepository;

	public MonitoringJob(ILogger<MonitoringJob> logger,
		IPoolService poolService,
		IDevicesService devicesService,
		IDeviceHistoryRepository deviceHistoryRepository)
	{
		_logger = logger;
		_poolService = poolService;
		_devicesService = devicesService;
		_deviceHistoryRepository = deviceHistoryRepository;
	}

	public async Task Execute(IJobExecutionContext context)
	{
		_logger.LogTrace("Получаем показатели");
		var pools = await _poolService.GetPoolsAsync(context.CancellationToken);
		foreach (var pool in pools)
		{
			var devices = await _devicesService.GetDevicesAsync(pool.Alias, context.CancellationToken);
			await _deviceHistoryRepository.InsertAsync(devices.Select(Map), context.CancellationToken);
		}
	}

	private static DeviceMonitoringEntity Map(DeviceIndicator indicator)
		=> new()
		{
			PoolAlias = indicator.PoolAlias,
			ControllerCode = indicator.ControllerCode,
			Type = indicator.Type,
			Date = indicator.Date,
			Value = indicator.Value
		};
}