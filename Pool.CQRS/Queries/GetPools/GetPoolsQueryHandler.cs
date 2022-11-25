using JetBrains.Annotations;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.CQRS.Queries.GetPools;

[UsedImplicitly]
internal sealed class GetPoolsQueryHandler : IQueryHandler<GetPoolsQuery, GetPoolsQueryResult>
{
	private readonly IPoolManager _poolManager;

	public GetPoolsQueryHandler(IPoolManager poolManager)
	{
		_poolManager = poolManager;
	}
	
	public async Task<GetPoolsQueryResult> Handle(GetPoolsQuery request, CancellationToken cancellationToken)
	{
		var pools = await _poolManager.GetPoolsAsync(cancellationToken);
		return new GetPoolsQueryResult(pools);
	}
}