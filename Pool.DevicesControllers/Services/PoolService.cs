using Microsoft.Extensions.Options;
using Pool.DevicesControllers.Abstractions.Models;
using Pool.DevicesControllers.Abstractions.Services;
using Pool.DevicesControllers.Settings;

namespace Pool.DevicesControllers.Services;

internal sealed class PoolService : IPoolService
{
	private readonly IOptions<PoolsSettings> _poolsSettings;

	public PoolService(IOptions<PoolsSettings> poolsSettings)
	{
		_poolsSettings = poolsSettings;
	}

	public Task<bool> IsPoolExistsAsync(string poolAlias, CancellationToken cancellationToken)
	{
		var result = !string.IsNullOrWhiteSpace(poolAlias) &&
		             _poolsSettings.Value.Pools.Any(x =>
			             x.Alias.Equals(poolAlias, StringComparison.OrdinalIgnoreCase));
		return Task.FromResult(result);
	}

#pragma warning disable CS1998
	public async Task<IReadOnlyCollection<PoolInfo>> GetPoolsAsync(CancellationToken calCancellationToken)
#pragma warning restore CS1998
	{
		return _poolsSettings.Value.Pools
			.Select(x => new PoolInfo(x.Name, x.Alias, x.Controllers.Select(MapToControllerInfo).ToArray()))
			.ToArray();
	}

	private static ControllerInfo MapToControllerInfo(ControllerSettings controllerSettings)
	{
		var devices = controllerSettings.Devices
			.Where(x => x.Enabled)
			.Select(x => x.Type)
			.ToArray();
		return new ControllerInfo(controllerSettings.Code, devices);
	}
}