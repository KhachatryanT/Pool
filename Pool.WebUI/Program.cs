using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using Pool.Api;
using Pool.Api.Application;
using Pool.Api.Application.Middleware;
using Pool.Api.Jobs;
using Pool.CQRS;
using Pool.DAL;
using Pool.DevicesController.Fake;
using Pool.DevicesControllers;
using Quartz;

if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")))
	Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("Init configure infrastructure services");
try
{
	builder.Services.AddControllers()
		.AddJsonOptions(options =>
		{
			options.JsonSerializerOptions.Converters.Add(
				new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
		});

	builder.Logging.ClearProviders();
	builder.Host.UseNLog();

	builder.Services.AddSwaggerGen(options =>
	{
		const string xmlFilename = $"{nameof(Pool)}.{nameof(Pool.Api)}.xml";
		options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
	});

	builder.Services.AddCQRS();
	builder.Services.AddDal();
	builder.Services.AddDevicesControllers(builder.Configuration.GetSection("Pools"));
	//services.AddCrystalDevicesController();
	builder.Services.AddFakeDevicesController();

	builder.Services.AddDbContext<PoolContext>(options =>
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


	builder.Host.UseSystemd();

	var app = builder.Build();
	await app.EnsureMigrationAsync<PoolContext>();

	app.UseStaticFiles();

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger(options => { options.RouteTemplate = $"api/{options.RouteTemplate}"; });
		app.UseSwaggerUI(options =>
		{
			options.SwaggerEndpoint("/api/swagger/v1/swagger.json", "v1");
			options.RoutePrefix = "api/swagger";
		});
	}

	app.UseRouting();
	app.UsePoolExceptionHandling();

	app.MapDefaultControllerRoute();

	app.MapFallbackToFile("index.html");
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