using Microsoft.Extensions.DependencyInjection;
using Pool.DAL.Repositories;
using Pool.Domain.Repositories;

namespace Pool.DAL;

public static class StartupSetup
{
	public static IServiceCollection AddDal(this IServiceCollection services)
	{
		services.AddScoped<IDeviceHistoryRepository, DeviceHistoryRepository>();
		return services;
	}
}