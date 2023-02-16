using Microsoft.Extensions.Options;
using Pool.Entities.Models;
using Pool.Infrastructure.Implementation.Options;
using Pool.Infrastructure.Interfaces.Services;

namespace Pool.Infrastructure.Implementation.Services;

internal sealed class PoolService : IPoolService
{
	private readonly IOptions<PoolsOptions> _poolsSettings;

	public PoolService(IOptions<PoolsOptions> poolsSettings)
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
	public async Task<IReadOnlyCollection<PoolInfo>> GetPoolsAsync(CancellationToken cancellationToken)
#pragma warning restore CS1998
	{
		return _poolsSettings.Value.Pools
			.Select(x => new PoolInfo(x.Name, x.Alias, x.Controllers.Select(MapToControllerInfo).ToArray()))
			.ToArray();
	}

	private static ControllerInfo MapToControllerInfo(ControllerOptions controllerOptions)
	{
		var devices = controllerOptions.Devices
			.Where(x => x.Enabled)
			.Select(x => x.Type)
			.ToArray();
		return new ControllerInfo(controllerOptions.Code, devices);
	}
}