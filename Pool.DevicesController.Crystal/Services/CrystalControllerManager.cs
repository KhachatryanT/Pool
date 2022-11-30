using Pool.DevicesControllers.Abstractions.Models;
using Pool.DevicesControllers.Abstractions.Services;
using Pool.Domain.Enums;

namespace Pool.DevicesController.Crystal.Services;

internal sealed class CrystalControllerManager : IControllerManager
{
#pragma warning disable CA1822
	bool IControllerManager.CanHandle(ControllerType type) => type == ControllerType.Crystal;
#pragma warning restore CA1822

	public Task<IReadOnlyCollection<DeviceValue>> GetDevicesCurrentValuesAsync(IEnumerable<DeviceType> types,
		CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}