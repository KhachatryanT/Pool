using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pool.Entities.Models;

namespace Pool.DataAccess.EF.Sqlite.Configuration;

internal sealed class PoolIndicatorEntityConfiguration : IEntityTypeConfiguration<PoolIndicator>
{
	public void Configure(EntityTypeBuilder<PoolIndicator> builder)
	{
		builder.Property(e => e.Date)
			.HasConversion(
				d => d.ToUniversalTime().ToString("u"),
				s => DateTimeOffset.Parse(s));
		
		builder.Property(e => e.Type)
			.HasConversion<string>();
	}
}