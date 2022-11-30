namespace Pool.CQRS.Queries.GetDevicesHistory;

public sealed class GetDevicesHistoryQuery : IQuery<GetDevicesHistoryQueryResult>
{
	public GetDevicesHistoryQuery(string poolAlias, DateTimeOffset startDate, DateTimeOffset endDate)
	{
		PoolAlias = poolAlias;
		StartDate = startDate;
		EndDate = endDate;
	}

	public string PoolAlias { get; }
	public DateTimeOffset StartDate { get; }
	public DateTimeOffset EndDate { get; }
}