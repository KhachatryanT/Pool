using Pool.DevicesControllers.Abstractions.Models;

namespace Pool.DevicesControllers.Abstractions.Services;

public interface IControllerManager
{
	bool CanHandle(ControllerType type);

	Task<IReadOnlyCollection<DeviceValue>> GetDevicesCurrentValuesAsync(IEnumerable<DeviceType> types,
		CancellationToken cancellationToken);
}