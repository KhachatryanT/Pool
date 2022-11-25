using Pool.Domain.Exceptions;

namespace Pool.DevicesControllers.Abstractions.Services;

public interface IPoolManager
{
	/// <summary>
	/// Существует ли указанный бассей
	/// </summary>
	/// <param name="poolAlias"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<bool> IsPoolExistsAsync(string poolAlias, CancellationToken cancellationToken);
}