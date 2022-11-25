using Pool.DevicesControllers.Abstractions.Models;

namespace Pool.CQRS.Queries.GetPools;

public sealed class GetPoolsQueryResult
{
	public GetPoolsQueryResult(IReadOnlyCollection<PoolInfo> pools)
	{
		Pools = pools;
	}

	public IReadOnlyCollection<PoolInfo> Pools { get; }
}