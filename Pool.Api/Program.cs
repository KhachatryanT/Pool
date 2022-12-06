using Pool.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApi(builder.Configuration);

var app = builder.Build();
await app.ConfigureApiAsync();
app.Run();