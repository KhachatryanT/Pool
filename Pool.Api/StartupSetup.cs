using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Pool.Api.Application;
using Pool.Api.Application.Middleware;
using Pool.Api.Jobs;
using Pool.CQRS;
using Pool.DAL;
using Pool.DevicesController.Fake;
using Pool.DevicesControllers;
using Quartz;

namespace Pool.Api;

public static class StartupSetup
{
	private const string BasePath = "/api";

	public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddControllers()
			.AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.Converters.Add(
					new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
			});
		services.AddSwaggerGen();

		services.AddCQRS();
		services.AddDal();
		services.AddDevicesControllers(configuration.GetSection("Pools"));
		//services.AddCrystalDevicesController();
		services.AddFakeDevicesController();

		services.AddDbContext<PoolContext>(options =>
		{
			var connection = configuration.GetConnectionString("Pool")
				.Replace('\\', Path.DirectorySeparatorChar)
				.Replace('/', Path.DirectorySeparatorChar);
			options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			options.UseSqlite(connection);
		});

		services.AddQuartz(q =>
		{
			q.UseMicrosoftDependencyInjectionJobFactory();
			q.AddJobAndTrigger<MonitoringJob>(configuration.GetSection("Quartz"));
		});
		services.AddQuartzHostedService();
		return services;
	}

	public static async Task ConfigureApiAsync(this WebApplication app)
	{
		app.UsePathBase(BasePath);
		await app.EnsureMigrationAsync<PoolContext>();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI(options => { options.SwaggerEndpoint($"{BasePath}/swagger/v1/swagger.json", "v1"); });
		}

		app.UseRouting();
		app.UsePoolExceptionHandling();

		app.MapDefaultControllerRoute();
	}
}