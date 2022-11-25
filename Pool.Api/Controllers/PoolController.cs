using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pool.CQRS.Queries.GetPools;

namespace Pool.Api.Controllers;

[Route("[controller]")]
public class PoolController : Controller
{
	private readonly ISender _sender;

	public PoolController(ISender sender)
	{
		_sender = sender;
	}

	/// <summary>
	/// Получить все бассейны
	/// </summary>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	[HttpGet]
	public Task<GetPoolsQueryResult> GetPools()
		=> _sender.Send(new GetPoolsQuery());
}