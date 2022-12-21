using Microsoft.AspNetCore.Mvc;
using Pool.DevicesControllers.Abstractions.Models;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.Api.Controllers;

[Route("api/[controller]")]
public class PoolController : ControllerBase
{
	private readonly IPoolService _poolService;

	public PoolController(IPoolService poolService)
	{
		_poolService = poolService;
	}

	/// <summary>
	/// Получить все бассейны и конфигурации
	/// </summary>
	[HttpGet]
	public Task<IReadOnlyCollection<PoolInfo>> GetPools()
		=> _poolService.GetPoolsAsync(Request.HttpContext.RequestAborted);
}