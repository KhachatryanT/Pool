using Microsoft.Extensions.DependencyInjection;
using Pool.DevicesController.Crystal.Services;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.DevicesController.Crystal;

public static class ImportModule
{
	public static IServiceCollection AddCrystalDevicesController(this IServiceCollection services)
	{
		services.AddSingleton<IControllerManager, CrystalControllerManager>();
		return services;
	}
}