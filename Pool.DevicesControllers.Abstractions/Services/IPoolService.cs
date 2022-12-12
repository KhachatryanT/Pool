using Pool.DevicesControllers.Abstractions.Models;

namespace Pool.DevicesControllers.Abstractions.Services;

public interface IPoolService
{
	/// <summary>
	/// Существует ли указанный бассей
	/// </summary>
	/// <param name="poolAlias"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<bool> IsPoolExistsAsync(string poolAlias, CancellationToken cancellationToken);

	/// <summary>
	/// Получить все бассейны
	/// </summary>
	/// <param name="calCancellationToken"></param>
	/// <returns></returns>
	Task<IReadOnlyCollection<PoolInfo>> GetPoolsAsync(CancellationToken calCancellationToken);
}