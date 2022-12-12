using Microsoft.Extensions.DependencyInjection;
using Pool.DevicesController.Fake.Services;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.DevicesController.Fake;

public static class StartupSetup
{
	public static IServiceCollection AddFakeDevicesController(this IServiceCollection services)
	{
		services.AddSingleton<IControllerService, FakeControllerService>();
		return services;
	}
}