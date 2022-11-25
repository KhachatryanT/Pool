using Pool.DevicesControllers.Abstractions.Models;

namespace Pool.CQRS.Queries.GetSensors;

public sealed class GetSensorsQueryResult
{
	public GetSensorsQueryResult(IReadOnlyCollection<DeviceIndicator> devices)
	{
		Devices = devices;
	}

	public IReadOnlyCollection<DeviceIndicator> Devices { get; }
}