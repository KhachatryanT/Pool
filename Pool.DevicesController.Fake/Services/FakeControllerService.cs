using Pool.DevicesControllers.Abstractions.Models;
using Pool.DevicesControllers.Abstractions.Services;
using Pool.Domain.Enums;

namespace Pool.DevicesController.Fake.Services;

internal sealed class FakeControllerService : IControllerService
{
	bool IControllerService.CanHandle(ControllerType type) => true;

	public async Task<IReadOnlyCollection<DeviceValue>> GetDevicesCurrentValuesAsync(IEnumerable<DeviceType> types,
		CancellationToken cancellationToken)
	{
		await Task.Delay(1500, cancellationToken);
		return types.Select(type => new DeviceValue
		{
			Date = DateTimeOffset.Now,
			Type = type,
			Value = new Random(Environment.TickCount).NextDouble()
		}).ToArray();
	}
}