using Pool.Entities.Enums;

namespace Pool.UseCases.Handlers.Devices.Queries.GetDeviceHistory;

public sealed class GetDeviceHistoryQuery : IQuery<GetDeviceHistoryQueryResult>
{
	public GetDeviceHistoryQuery(string poolAlias,
		DeviceType[] types,
		FractionType fractionType,
		DateTimeOffset startDate,
		DateTimeOffset endDate)
	{
		PoolAlias = poolAlias;
		Types = types;
		FractionType = fractionType;
		StartDate = startDate;
		EndDate = endDate;
	}

	public string PoolAlias { get; }
	public DeviceType[] Types { get; }
	public FractionType FractionType { get; }
	public DateTimeOffset StartDate { get; }
	public DateTimeOffset EndDate { get; }
}