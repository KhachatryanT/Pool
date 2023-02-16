using Microsoft.Extensions.DependencyInjection;
using Pool.Infrastructure.Interfaces.Services;

namespace Pool.Infrastructure.DevicesControllers.Fake;

public static class StartupSetup
{
	public static IServiceCollection AddFakeDevicesController(this IServiceCollection services)
	{
		services.AddSingleton<IDeviceControllerService, FakeDeviceControllerService>();
		return services;
	}
}