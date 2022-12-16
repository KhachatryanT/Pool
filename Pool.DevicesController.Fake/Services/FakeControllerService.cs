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
		await Task.Delay(1000, cancellationToken);
		return types.Select(type => new DeviceValue
		{
			Date = DateTimeOffset.Now,
			Type = type,
			Value = GetRandomValue(type)
		}).ToArray();
	}

	private static double GetRandomValue(DeviceType type) =>
		type switch
		{
			DeviceType.Ph => Math.Round(GetRandomValue(6.8, 8), 2),
			DeviceType.Cl => Math.Round(GetRandomValue(0.2, 1.5), 2),
			DeviceType.Rx => GetRandomValue(300, 900),
			DeviceType.Temp => Math.Round(GetRandomValue(24.0, 27.0), 1),
			_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
		};

	private static double GetRandomValue(double minimum, double maximum)
	{
		return new Random(Environment.TickCount).NextDouble() * (maximum - minimum) + minimum;
	}

	private static int GetRandomValue(int minimum, int maximum)
	{
		return new Random(Environment.TickCount).Next(minimum, maximum);
	}
}