using Microsoft.AspNetCore.Mvc;
using Pool.DevicesControllers.Abstractions.Models;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.Api.Controllers;

[Route("[controller]")]
public class PoolController : Controller
{
	private readonly IPoolManager _poolManager;

	public PoolController(IPoolManager poolManager)
	{
		_poolManager = poolManager;
	}

	/// <summary>
	/// Получить все бассейны
	/// </summary>
	[HttpGet]
	public Task<IReadOnlyCollection<PoolInfo>> GetPools()
		=> _poolManager.GetPoolsAsync(Request.HttpContext.RequestAborted);
}