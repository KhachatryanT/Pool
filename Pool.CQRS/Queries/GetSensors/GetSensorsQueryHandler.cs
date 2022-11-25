using JetBrains.Annotations;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.CQRS.Queries.GetSensors;

[UsedImplicitly]
internal sealed class GetSensorsQueryHandler : IQueryHandler<GetSensorsQuery, GetSensorsQueryResult>
{
	private readonly IDevicesManager _devicesManager;

	public GetSensorsQueryHandler(IDevicesManager devicesManager)
	{
		_devicesManager = devicesManager;
	}

	public async Task<GetSensorsQueryResult> Handle(GetSensorsQuery request, CancellationToken cancellationToken)
	{
		var devices = await _devicesManager.GetDevicesAsync(request.PoolAlias, cancellationToken);
		return new GetSensorsQueryResult(devices);
	}
}