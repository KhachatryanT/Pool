using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;
using Pool.Entities.Models;
using Pool.Infrastructure.Interfaces.DataAccess;

namespace Pool.DataAccess.EF.Sqlite;

public sealed class PoolDbContext : DbContext, IDbContext
{
#pragma warning disable CS8618
	public PoolDbContext(DbContextOptions<PoolDbContext> options) : base(options)
#pragma warning restore CS8618
	{
#pragma warning disable EF1001
		var sqliteExtension = options.FindExtension<SqliteOptionsExtension>();
#pragma warning restore EF1001
		if (sqliteExtension is not null && !string.IsNullOrEmpty(sqliteExtension.ConnectionString))
		{
			EnsureCreated(sqliteExtension.ConnectionString.Replace("Data Source=",
				string.Empty,
				StringComparison.OrdinalIgnoreCase));
		}
	}

	public DbSet<PoolIndicator> PoolIndicators { get; init; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(PoolDbContext).Assembly);
	}

	private void EnsureCreated(string dbPath)
	{
		var fi = new FileInfo(dbPath);

		if (fi.Directory is not null && !fi.Directory.Exists)
		{
			fi.Directory.Create();
		}
	}
}