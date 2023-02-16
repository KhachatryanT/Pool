using Microsoft.AspNetCore.Mvc;
using Pool.Entities.Models;
using Pool.Infrastructure.Interfaces.Services;

namespace Pool.Controllers;

/// <summary>
/// Методы взаимодействия с бассейнами
/// </summary>
[Route("api/pool")]
public class PoolsController : ControllerBase
{
	private readonly IPoolService _poolService;

	public PoolsController(IPoolService poolService)
	{
		_poolService = poolService;
	}

	/// <summary>
	/// Получить все бассейны и их конфигурации
	/// </summary>
	[HttpGet]
	public Task<IReadOnlyCollection<PoolInfo>> GetPools()
		=> _poolService.GetPoolsAsync(Request.HttpContext.RequestAborted);
}