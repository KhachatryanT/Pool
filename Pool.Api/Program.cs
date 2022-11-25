using System.Text.Json;
using System.Text.Json.Serialization;
using Pool.Api.Application.Middleware;
using Pool.CQRS;
using Pool.DevicesController.Crystal;
using Pool.DevicesController.Fake;
using Pool.DevicesControllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
	});
builder.Services.AddSwaggerGen();

builder.Services.AddCQRS();
builder.Services.AddDevicesControllers(builder.Configuration.GetSection("Pools"));
//builder.Services.AddCrystalDevicesController();
builder.Services.AddFakeDevicesController();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
		options.RoutePrefix = string.Empty;
	});
	//app.UseMigrationsEndPoint();
}

app.UseStaticFiles();

app.UseRouting();
app.UsePoolExceptionHandling();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();