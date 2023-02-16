using Pool.Entities.Enums;
using Pool.Entities.Models;
using Pool.Infrastructure.Interfaces.Services;

namespace Pool.Infrastructure.DevicesControllers.Crystal;

internal sealed class CrystalDeviceControllerService : IDeviceControllerService
{
#pragma warning disable CA1822
	bool IDeviceControllerService.CanHandle(ControllerType type) => type == ControllerType.Crystal;
	public Task<IReadOnlyCollection<IndicatorOfDevice>> GetDevicesCurrentValuesAsync(IEnumerable<DeviceType> types, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
#pragma warning restore CA1822

}