using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pool.DevicesControllers.Abstractions.Services;
using Pool.DevicesControllers.Services;
using Pool.DevicesControllers.Settings;

namespace Pool.DevicesControllers;

public static class ImportModule
{
	public static IServiceCollection AddDevicesControllers(this IServiceCollection services, IConfiguration pools)
	{
		_ = services.AddOptions<PoolsSettings>()
			.Bind(pools)
			.ValidateDataAnnotations()
			.ValidateOnStart();

		services.AddScoped<IPoolManager, PoolManager>();
		services.AddScoped<IDevicesManager, DevicesManager>();
		return services;
	}
}