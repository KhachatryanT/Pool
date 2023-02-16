using Pool.Entities.Enums;
using Pool.Entities.Models;
using Pool.Infrastructure.DevicesControllers.Fake.Models;
using Pool.Infrastructure.Interfaces.Services;

namespace Pool.Infrastructure.DevicesControllers.Fake;

internal sealed class FakeDeviceControllerService : IDeviceControllerService
{
	bool IDeviceControllerService.CanHandle(ControllerType type) => true;

	public async Task<IReadOnlyCollection<IndicatorOfDevice>> GetDevicesCurrentValuesAsync(
		IEnumerable<DeviceType> types, CancellationToken cancellationToken)
	{
		var now = DateTimeOffset.UtcNow;
		await Task.Delay(1000, cancellationToken);
		return types
			.Select(type => new IndicatorOfDevice(type, new IndicatorValue(now, GetRandomValue(type), CreateDetails(type))))
			.ToArray();
	}

	private static IndicatorDetailsBase CreateDetails(DeviceType type) =>
		type switch
		{
			DeviceType.Ph => new PhDetails(),
			DeviceType.Cl => new ClDetails(),
			DeviceType.Rx => new RxDetails(),
			DeviceType.Temp => new TempDetails(),
			_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
		};

	private static double GetRandomValue(DeviceType type) =>
		type switch
		{
			DeviceType.Ph => GetRandomValue(6.8, 8),
			DeviceType.Cl => GetRandomValue(0.2, 1.5),
			DeviceType.Rx => GetRandomValue(300, 900),
			DeviceType.Temp => GetRandomValue(24.0, 27.0),
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