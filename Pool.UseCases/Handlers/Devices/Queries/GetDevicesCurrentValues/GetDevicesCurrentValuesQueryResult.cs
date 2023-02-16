using Pool.Entities.Models;

namespace Pool.UseCases.Handlers.Devices.Queries.GetDevicesCurrentValues;

public sealed class GetDevicesCurrentValuesQueryResult
{
	public GetDevicesCurrentValuesQueryResult(IReadOnlyCollection<IndicatorOfDevice> devices)
	{
		Devices = devices;
	}

	public IReadOnlyCollection<IndicatorOfDevice> Devices { get; }

}