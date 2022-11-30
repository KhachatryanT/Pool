using Microsoft.EntityFrameworkCore;
using Pool.Domain.Entities;
using Pool.Domain.Repositories;

namespace Pool.DAL.Repositories;

public sealed class DeviceHistoryRepository : IDeviceHistoryRepository
{
	private readonly PoolContext _poolContext;

	public DeviceHistoryRepository(PoolContext poolContext)
	{
		_poolContext = poolContext;
	}

	public async Task InsertAsync(IEnumerable<DeviceMonitoringEntity> devices, CancellationToken cancellationToken)
	{
		_poolContext.DeviceMonitoringEntities.AddRange(devices);
		await _poolContext.SaveChangesAsync(cancellationToken);
	}

	public async Task<IReadOnlyCollection<DeviceMonitoringEntity>> GetAsync(
		DateTimeOffset startDate,
		DateTimeOffset endDate,
		string poolAlias,
		CancellationToken cancellationToken)
	{
		return await _poolContext.DeviceMonitoringEntities
			.Where(x => x.PoolAlias == poolAlias && x.Date >= startDate && x.Date <= endDate)
			.ToArrayAsync(cancellationToken);
	}
}