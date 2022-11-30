﻿using Microsoft.EntityFrameworkCore;

namespace Pool.Api.Application;

internal static class MigrationExtensions
{
	public static async Task EnsureMigrationAsync<T>(this IApplicationBuilder app)
		where T : DbContext
	{
		var hostApplicationLifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
		using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

		var context = serviceScope.ServiceProvider.GetRequiredService<T>();
		await context.Database.MigrateAsync(hostApplicationLifetime.ApplicationStopping);
	}
}