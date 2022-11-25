using Microsoft.Extensions.DependencyInjection;
using Pool.DevicesController.Fake.Services;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.DevicesController.Fake;

public static class ImportModule
{
	public static IServiceCollection AddFakeDevicesController(this IServiceCollection services)
	{
		services.AddSingleton<IControllerManager, FakeControllerManager>();
		return services;
	}
}