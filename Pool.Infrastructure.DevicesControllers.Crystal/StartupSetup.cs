using Microsoft.Extensions.DependencyInjection;
using Pool.Infrastructure.Interfaces.Services;

namespace Pool.Infrastructure.DevicesControllers.Crystal;

public static class StartupSetup
{
	public static IServiceCollection AddCrystalDevicesController(this IServiceCollection services)
	{
		services.AddSingleton<IDeviceControllerService, CrystalDeviceControllerService>();
		return services;
	}
}