using Pool.Entities.Enums;
using Pool.Entities.Models;

namespace Pool.Infrastructure.Interfaces.Services;

/// <summary>
/// Интерфейс, реализуемый на стороне контроллеров (Crystal, Navigator, etc)
/// </summary>
public interface IDeviceControllerService
{
	bool CanHandle(ControllerType type);
	
	/// <summary>
	/// Получить все показатели устройств
	/// </summary>
	/// <param name="types"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IReadOnlyCollection<IndicatorOfDevice>> GetDevicesCurrentValuesAsync(IEnumerable<DeviceType> types,
		CancellationToken cancellationToken);
}