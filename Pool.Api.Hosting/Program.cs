using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using NLog;
using NLog.Web;
using Pool.Api.Hosting.Application;
using Pool.Api.Hosting.Application.Middleware;
using Pool.DataAccess.EF.Sqlite;
using Pool.Infrastructure.DevicesControllers.Fake;
using Pool.Infrastructure.Implementation;
using Pool.Infrastructure.Implementation.BackgroundJobs;
using Pool.Infrastructure.Interfaces.DataAccess;
using Pool.UseCases;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("Init");
try
{
	builder.Services.AddControllers()
		// Используем Newtonsoft.Json потому что System.Text.Json не может сериализовать свойства дочерних объектов
		// (от части из-за направлений связей в проектах)
		.AddNewtonsoftJson(options =>
		{
			options.SerializerSettings.Converters.Add(new StringEnumConverter());
		});

	builder.Logging.ClearProviders();
	builder.Host.UseNLog();

	builder.Services.AddSwaggerGen(options =>
	{
		const string xmlFilename = $"{nameof(Pool)}.{nameof(Pool.Controllers)}.xml";
		options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
		options.SchemaFilter<EnumSchemaFilter>();
	});

	builder.Services.AddUseCases();
	builder.Services.AddInfrastructureServices(builder.Configuration.GetSection("Pools"));
	//services.AddCrystalDevicesController();
	builder.Services.AddFakeDevicesController();

	builder.Services.AddDbContext<IDbContext, PoolDbContext>(options =>
	{
		var connection = builder.Configuration.GetConnectionString("Pool")
			.Replace('\\', Path.DirectorySeparatorChar)
			.Replace('/', Path.DirectorySeparatorChar);
		options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		options.UseSqlite(connection);
	});

	builder.Services.AddQuartz(q =>
	{
		q.UseMicrosoftDependencyInjectionJobFactory();
		q.AddJobAndTrigger<MonitoringJob>(builder.Configuration.GetSection("Quartz"));
	});
	builder.Services.AddQuartzHostedService();

	var app = builder.Build();
	await app.EnsureMigrationAsync<PoolDbContext>();

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger(options => { options.RouteTemplate = $"api/{options.RouteTemplate}";  });
		app.UseSwaggerUI(options =>
		{
			options.SwaggerEndpoint("/api/swagger/v1/swagger.json", "v1");
			options.RoutePrefix = "api/swagger";
		});
	}

	app.UseRouting();
	app.UsePoolExceptionHandling();

	app.MapDefaultControllerRoute();
	await app.RunAsync();
}
catch (Exception e)
{
	logger.Error(e, "Stopped program because of exception");
	throw;
}
finally
{
	// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
	LogManager.Shutdown();
}