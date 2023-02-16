using Microsoft.Extensions.Options;
using Pool.Entities.Models;
using Pool.Infrastructure.Implementation.Options;
using Pool.Infrastructure.Interfaces.Services;

namespace Pool.Infrastructure.Implementation.Services;

internal sealed class IndicatorService : IIndicatorService
{
	private readonly IOptions<PoolsOptions> _poolsSettings;
	private readonly IEnumerable<IDeviceControllerService> _deviceControllerServices;

	public IndicatorService(IOptions<PoolsOptions> poolsSettings,
		IEnumerable<IDeviceControllerService> deviceControllerServices)
	{
		_poolsSettings = poolsSettings;
		_deviceControllerServices = deviceControllerServices;
	}

	public async Task<IReadOnlyCollection<DeviceOfController>> GetDevicesCurrentValuesAsync(string poolAlias,
		CancellationToken cancellationToken)
	{
		var pool = _poolsSettings.Value.Pools
			.SingleOrDefault(x => x.Alias.Equals(poolAlias, StringComparison.OrdinalIgnoreCase));
		if (pool is null)
		{
			return Array.Empty<DeviceOfController>();
		}

		var indicators = new List<DeviceOfController>();
		foreach (var controller in pool.Controllers)
		{
			var controllerManager = _deviceControllerServices.Single(x => x.CanHandle(controller.Type));
			var types = controller.Devices
				.Where(x => x.Enabled)
				.Select(x => x.Type);

			var controllerIndicators = await controllerManager.GetDevicesCurrentValuesAsync(types, cancellationToken);
			indicators.AddRange(controllerIndicators.Select(x => new DeviceOfController(controller.Code, x)));
		}

		return indicators;
	}
}