using Microsoft.Extensions.Options;
using Pool.DevicesControllers.Abstractions.Models;
using Pool.DevicesControllers.Abstractions.Services;
using Pool.DevicesControllers.Settings;

namespace Pool.DevicesControllers.Services;

internal sealed class DevicesManager : IDevicesManager
{
	private readonly IOptions<PoolsSettings> _poolsSettings;
	private readonly IEnumerable<IControllerManager> _controllerManagers;

	public DevicesManager(IOptions<PoolsSettings> poolsSettings,
		IEnumerable<IControllerManager> controllerManagers)
	{
		_poolsSettings = poolsSettings;
		_controllerManagers = controllerManagers;
	}

	public async Task<IReadOnlyCollection<DeviceIndicator>> GetDevicesAsync(string poolAlias,
		CancellationToken cancellationToken)
	{
		var pool = _poolsSettings.Value.Pools.SingleOrDefault(x =>
			x.Alias.Equals(poolAlias, StringComparison.OrdinalIgnoreCase));
		if (pool is null)
		{
			return Array.Empty<DeviceIndicator>();
		}

		var devices = new List<DeviceIndicator>();
		foreach (var controller in pool.Controllers)
		{
			var controllerManager = _controllerManagers.Single(x => x.CanHandle(controller.Type));
			var types = controller.Devices
				.Where(x => x.Enabled)
				.Select(x => x.Type);

			var currentValues = await controllerManager.GetDevicesCurrentValuesAsync(types, cancellationToken);
			devices.AddRange(currentValues.Select(currentValue => new DeviceIndicator(pool.Alias, controller.Code)
			{
				CurrentValue = currentValue
			}));
		}

		return devices;
	}
}