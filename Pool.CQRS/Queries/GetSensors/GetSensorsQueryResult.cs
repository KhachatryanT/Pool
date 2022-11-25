using Pool.DevicesControllers.Abstractions.Models;

namespace Pool.CQRS.Queries.GetSensors;

public sealed class GetSensorsQueryResult
{
	public GetSensorsQueryResult(IReadOnlyCollection<DeviceInfo> devices)
	{
		Devices = devices;
	}

	public IReadOnlyCollection<DeviceInfo> Devices { get; }
}