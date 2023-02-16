using Microsoft.EntityFrameworkCore;
using Pool.Entities.Models;

namespace Pool.Infrastructure.Interfaces.DataAccess;

public interface IDbContext
{
	public DbSet<PoolIndicator> PoolIndicators { get; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}