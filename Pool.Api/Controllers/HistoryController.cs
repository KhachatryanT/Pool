using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pool.CQRS.Queries.GetDevicesHistory;

namespace Pool.Api.Controllers;

[Route("api/[controller]")]
public class HistoryController : ControllerBase
{
	private readonly ISender _sender;

	public HistoryController(ISender sender)
	{
		_sender = sender;
	}

	/// <summary>
	/// История показателей бассейна
	/// </summary>
	/// <param name="poolAlias">Псевдоним бассейна</param>
	/// <param name="startDate">Дата начала</param>
	/// <param name="endDate">Дата окончания</param>
	[HttpGet("{poolAlias}")]
	public Task<GetDevicesHistoryQueryResult> GetPools([FromRoute] string poolAlias, DateTimeOffset startDate, DateTimeOffset endDate)
		=> _sender.Send(new GetDevicesHistoryQuery(poolAlias, startDate, endDate));
}