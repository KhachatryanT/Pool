using Microsoft.AspNetCore.Mvc;
using Pool.DevicesControllers.Abstractions.Models;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.Api.Controllers;

[Route("[controller]")]
public class PoolController : Controller
{
	private readonly IPoolService _poolService;

	public PoolController(IPoolService poolService)
	{
		_poolService = poolService;
	}

	/// <summary>
	/// Получить все бассейны
	/// </summary>
	[HttpGet]
	public Task<IReadOnlyCollection<PoolInfo>> GetPools()
		=> _poolService.GetPoolsAsync(Request.HttpContext.RequestAborted);
}