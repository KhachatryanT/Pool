using JetBrains.Annotations;
using Pool.DevicesControllers.Abstractions.Models;
using Pool.Domain.Repositories;

namespace Pool.CQRS.Queries.GetDevicesHistory;

[UsedImplicitly]
internal sealed class GetDevicesHistoryQueryHandler : IQueryHandler<GetDevicesHistoryQuery, GetDevicesHistoryQueryResult>
{
	private readonly IDeviceHistoryRepository _deviceHistoryRepository;

	public GetDevicesHistoryQueryHandler(IDeviceHistoryRepository deviceHistoryRepository)
	{
		_deviceHistoryRepository = deviceHistoryRepository;
	}

	public async Task<GetDevicesHistoryQueryResult> Handle(GetDevicesHistoryQuery request,
		CancellationToken cancellationToken)
	{
		var history = await _deviceHistoryRepository.GetAsync(request.StartDate,
			request.EndDate,
			request.PoolAlias,
			cancellationToken);
		return new GetDevicesHistoryQueryResult(history.Select(x =>
			new DeviceIndicator(x.PoolAlias, x.ControllerCode, x.Type, x.Date, x.Value)).ToArray());
	}
}