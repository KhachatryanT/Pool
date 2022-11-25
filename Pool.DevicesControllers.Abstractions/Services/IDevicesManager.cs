using Pool.DevicesControllers.Abstractions.Models;

namespace Pool.DevicesControllers.Abstractions.Services;

public interface IDevicesManager
{
	/// <summary>
	/// Получить показатели всех устройств
	/// </summary>
	/// <param name="poolAlias"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IReadOnlyCollection<DeviceInfo>> GetDevicesAsync(string poolAlias, CancellationToken cancellationToken);
}