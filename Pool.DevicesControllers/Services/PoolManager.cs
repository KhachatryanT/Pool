using Microsoft.Extensions.Options;
using Pool.DevicesControllers.Abstractions.Services;
using Pool.DevicesControllers.Settings;

namespace Pool.DevicesControllers.Services;

internal sealed class PoolManager : IPoolManager
{
	private readonly IOptions<PoolsSettings> _poolsSettings;

	public PoolManager(IOptions<PoolsSettings> poolsSettings)
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
}