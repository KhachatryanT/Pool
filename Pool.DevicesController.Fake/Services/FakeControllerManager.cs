using Pool.DevicesControllers.Abstractions.Models;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.DevicesController.Fake.Services;

internal sealed class FakeControllerManager : IControllerManager
{
	bool IControllerManager.CanHandle(ControllerType type) => true;

	public async Task<IReadOnlyCollection<DeviceValue>> GetDevicesCurrentValuesAsync(IEnumerable<DeviceType> types,
		CancellationToken cancellationToken)
	{
		await Task.Delay(2000, cancellationToken);
		return types.Select(type => new DeviceValue
		{
			Type = type,
			Value = new Random(Environment.TickCount).NextDouble()
		}).ToArray();
	}
}