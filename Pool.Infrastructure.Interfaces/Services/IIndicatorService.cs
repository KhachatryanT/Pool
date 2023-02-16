using Pool.Entities.Models;

namespace Pool.Infrastructure.Interfaces.Services;

public interface IIndicatorService
{
	/// <summary>
	/// Получить все устройства контроллеров с показателями
	/// </summary>
	/// <param name="poolAlias"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IReadOnlyCollection<DeviceOfController>> GetDevicesCurrentValuesAsync(string poolAlias, CancellationToken cancellationToken);
}