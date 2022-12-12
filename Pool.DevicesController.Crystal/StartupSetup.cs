using Microsoft.Extensions.DependencyInjection;
using Pool.DevicesController.Crystal.Services;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.DevicesController.Crystal;

public static class StartupSetup
{
	public static IServiceCollection AddCrystalDevicesController(this IServiceCollection services)
	{
		services.AddSingleton<IControllerService, CrystalControllerService>();
		return services;
	}
}