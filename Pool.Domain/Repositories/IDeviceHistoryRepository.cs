using Pool.Domain.Entities;

namespace Pool.Domain.Repositories;

public interface IDeviceHistoryRepository
{
	Task InsertAsync(IEnumerable<DeviceMonitoringEntity> devices, CancellationToken cancellationToken);

	Task<IReadOnlyCollection<DeviceMonitoringEntity>> GetAsync(
		DateTimeOffset startDate,
		DateTimeOffset endDate,
		string poolAlias,
		CancellationToken cancellationToken);
}