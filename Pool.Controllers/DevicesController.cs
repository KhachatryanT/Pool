using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pool.Entities.Enums;
using Pool.UseCases.Handlers.Devices.Queries.GetDeviceHistory;
using Pool.UseCases.Handlers.Devices.Queries.GetDevicesCurrentValues;
using Pool.UseCases.Handlers.Devices.Queries.GetNormalizedDeviceHistory;

namespace Pool.Controllers;

/// <summary>
/// Методы взаимодействия с утройствами контроллеров (датчиками)
/// </summary>
[Route("api/pool/{poolAlias}/devices")]
public class DevicesController : ControllerBase
{
	private readonly ISender _sender;

	public DevicesController(ISender sender)
	{
		_sender = sender;
	}

	/// <summary>
	/// Получить текущие показатели всех устройств(датчиков) бассейна
	/// </summary>
	/// <param name="poolAlias"></param>
	[HttpGet("current")]
	public async Task<GetDevicesCurrentValuesQueryResult> GetDevicesCurrentValues([FromRoute] string poolAlias) =>
		await _sender.Send(new GetDevicesCurrentValuesQuery(poolAlias));

	/// <summary>
	/// Получение исторических данных
	/// </summary>
	/// <param name="poolAlias"></param>
	/// <param name="types"></param>
	/// <param name="fractionType"></param>
	/// <param name="startDate"></param>
	/// <param name="endDate"></param>
	/// <returns></returns>
	[HttpGet("history")]
	public Task<GetDeviceHistoryQueryResult> GetPoolDeviceHistory([FromRoute] string poolAlias,
		DeviceType[] types,
		FractionType fractionType,
		DateTimeOffset startDate,
		DateTimeOffset endDate) =>
		_sender.Send(new GetDeviceHistoryQuery(poolAlias,
			types,
			fractionType,
			startDate,
			endDate));

	/// <summary>
	/// Получение нормализованных исторических данных
	/// </summary>
	/// <param name="poolAlias"></param>
	/// <param name="types"></param>
	/// <param name="fractionType"></param>
	/// <param name="startDate"></param>
	/// <param name="endDate"></param>
	/// <remarks>
	/// Для отображения показателей разных типов устройств на одном графике 
	/// </remarks>
	[HttpGet("history/normalized")]
	public Task<GetNormalizedDeviceHistoryQueryResult> GetPoolDeviceNormalizedHistory([FromRoute] string poolAlias,
		DeviceType[] types,
		FractionType fractionType,
		DateTimeOffset startDate,
		DateTimeOffset endDate) =>
		_sender.Send(new GetNormalizedDeviceHistoryQuery(poolAlias,
			types,
			fractionType,
			startDate,
			endDate));
}