using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pool.CQRS.Queries.GetSensors;

namespace Pool.Api.Controllers;

[Route("[controller]")]
public class DevicesController : Controller
{
	private readonly ISender _sender;

	public DevicesController(ISender sender)
	{
		_sender = sender;
	}

	/// <summary>
	/// Получить показатели всех устройств(датчиков) бассейна
	/// </summary>
	/// <param name="poolAlias"></param>
	[HttpGet("{poolAlias}")]
	public Task<GetSensorsQueryResult> GetDevices([FromRoute] string poolAlias)
		=> _sender.Send(new GetSensorsQuery(poolAlias));
}