using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pool.Infrastructure.Implementation.Options;
using Pool.Infrastructure.Implementation.Services;
using Pool.Infrastructure.Interfaces.Services;

namespace Pool.Infrastructure.Implementation;

public static class StartupSetup
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration pools)
	{
		_ = services.AddOptions<PoolsOptions>()
			.Bind(pools)
			.ValidateDataAnnotations()
			.ValidateOnStart();

		services.AddScoped<IPoolService, PoolService>();
		services.AddScoped<IIndicatorService, IndicatorService>();
		return services;
	}
}