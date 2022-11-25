namespace Pool.CQRS.Queries.GetSensors;

public sealed class GetSensorsQuery : IQuery<GetSensorsQueryResult>
{
	public GetSensorsQuery(string poolAlias)
	{
		PoolAlias = poolAlias;
	}

	public string PoolAlias { get; }
}