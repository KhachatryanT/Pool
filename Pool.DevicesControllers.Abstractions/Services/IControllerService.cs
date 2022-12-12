using Pool.DevicesControllers.Abstractions.Models;
using Pool.Domain.Enums;
namespace Pool.DevicesControllers.Abstractions.Services;

public interface IControllerService
{
	bool CanHandle(ControllerType type);

	/// <summary>
	/// Получить показатели всех доступных устройств контроллера
	/// </summary>
	/// <param name="types"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IReadOnlyCollection<DeviceValue>> GetDevicesCurrentValuesAsync(IEnumerable<DeviceType> types,
		CancellationToken cancellationToken);
}