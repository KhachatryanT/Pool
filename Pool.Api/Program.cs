using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Pool.Api.Application;
using Pool.Api.Application.Middleware;
using Pool.Api.Jobs;
using Pool.CQRS;
using Pool.DAL;
using Pool.DevicesController.Crystal;
using Pool.DevicesController.Fake;
using Pool.DevicesControllers;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
	});
builder.Services.AddSwaggerGen();

builder.Services.AddCQRS();
builder.Services.AddDal();
builder.Services.AddDevicesControllers(builder.Configuration.GetSection("Pools"));
//builder.Services.AddCrystalDevicesController();
builder.Services.AddFakeDevicesController();

builder.Services.AddDbContext<PoolContext>(options=>
{
	options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	options.UseSqlite(builder.Configuration.GetConnectionString("Pool"));
});

builder.Services.AddQuartz(q =>
{
	q.UseMicrosoftDependencyInjectionJobFactory();
	q.AddJobAndTrigger<MonitoringJob>(builder.Configuration.GetSection("Quartz"));
});
builder.Services.AddQuartzHostedService();

var app = builder.Build();

await app.EnsureMigrationAsync<PoolContext>();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();
app.UsePoolExceptionHandling();

app.MapDefaultControllerRoute();

app.Run();