using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pool.DevicesControllers.Abstractions.Services;
using Pool.DevicesControllers.Services;
using Pool.DevicesControllers.Settings;

namespace Pool.DevicesControllers;

public static class StartupSetup
{
	public static IServiceCollection AddDevicesControllers(this IServiceCollection services, IConfiguration pools)
	{
		_ = services.AddOptions<PoolsSettings>()
			.Bind(pools)
			.ValidateDataAnnotations()
			.ValidateOnStart();

		services.AddScoped<IPoolService, PoolService>();
		services.AddScoped<IDevicesService, DevicesService>();
		return services;
	}
}