using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pool.CQRS.Queries.GetSensors;

namespace Pool.Api.Controllers;

[Route("[controller]")]
public class TestController : Controller
{
	private readonly ISender _sender;

	public TestController(ISender sender)
	{
		_sender = sender;
	}

	[HttpGet]
	public async Task<IActionResult> Index(string alias)
	{
		var res = await _sender.Send(new GetSensorsQuery(alias));
		return Ok(res);
	}
}