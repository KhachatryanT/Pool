using Pool.DevicesControllers.Abstractions.Models;

namespace Pool.CQRS.Queries.GetDevicesHistory;

public sealed class GetDevicesHistoryQueryResult
{
	public GetDevicesHistoryQueryResult(IReadOnlyCollection<DeviceIndicator> devices)
	{
		Devices = devices;
	}

	public IReadOnlyCollection<DeviceIndicator> Devices { get; }
}