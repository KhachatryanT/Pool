using JetBrains.Annotations;
using Pool.Infrastructure.Interfaces.Services;
using Pool.UseCases.Utils;

namespace Pool.UseCases.Handlers.Devices.Queries.GetDevicesCurrentValues;

[UsedImplicitly]
internal sealed class GetDevicesCurrentValuesQueryHandler
	: IQueryHandler<GetDevicesCurrentValuesQuery, GetDevicesCurrentValuesQueryResult>
{
	private readonly IIndicatorService _indicatorService;

	public GetDevicesCurrentValuesQueryHandler(IIndicatorService indicatorService)
	{
		_indicatorService = indicatorService;
	}

	public async Task<GetDevicesCurrentValuesQueryResult> Handle(GetDevicesCurrentValuesQuery request,
		CancellationToken cancellationToken)
	{
		var deviceIndicators = await _indicatorService.GetDevicesCurrentValuesAsync(request.PoolAlias, cancellationToken);
		var devices = deviceIndicators
			.Select(x =>
			{
				var precision = DevicesHelpers.DevicePrecision(x.Device.Type);
				x.Device.Indicator.SetPrecision(precision);
				return x.Device;
			});
		return new GetDevicesCurrentValuesQueryResult(devices.ToArray());
	}
}