using Microsoft.EntityFrameworkCore;
using Pool.Domain.Entities;

namespace Pool.DAL;

public sealed class PoolContext : DbContext
{
#pragma warning disable CS8618
	public PoolContext(DbContextOptions<PoolContext> options) : base(options)
#pragma warning restore CS8618
	{
	}
	
	// ReSharper disable once UnusedAutoPropertyAccessor.Global
	public DbSet<DeviceMonitoringEntity> DeviceMonitoringEntities { get; init; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(PoolContext).Assembly);
	}
}