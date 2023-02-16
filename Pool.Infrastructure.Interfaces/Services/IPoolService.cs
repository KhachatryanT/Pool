using Pool.Entities.Models;

namespace Pool.Infrastructure.Interfaces.Services;

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
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IReadOnlyCollection<PoolInfo>> GetPoolsAsync(CancellationToken cancellationToken);
}