using JetBrains.Annotations;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.CQRS.Queries.GetSensors;

[UsedImplicitly]
internal sealed class GetSensorsQueryHandler : IQueryHandler<GetSensorsQuery, GetSensorsQueryResult>
{
	private readonly IDevicesService _devicesService;

	public GetSensorsQueryHandler(IDevicesService devicesService)
	{
		_devicesService = devicesService;
	}

	public async Task<GetSensorsQueryResult> Handle(GetSensorsQuery request, CancellationToken cancellationToken)
	{
		var devices = await _devicesService.GetDevicesAsync(request.PoolAlias, cancellationToken);
		return new GetSensorsQueryResult(devices);
	}
}