using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pool.Domain.Entities;

namespace Pool.DAL.Configuration;

internal sealed class DeviceMonitoringEntityConfiguration : IEntityTypeConfiguration<DeviceMonitoringEntity>
{
	public void Configure(EntityTypeBuilder<DeviceMonitoringEntity> builder)
	{
		builder.Property(e => e.Date)
			.HasConversion(
				d => d.ToUniversalTime().ToString("u"),
				s => DateTimeOffset.Parse(s));
	}
}