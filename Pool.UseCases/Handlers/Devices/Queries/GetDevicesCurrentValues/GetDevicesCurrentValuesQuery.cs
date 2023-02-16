namespace Pool.UseCases.Handlers.Devices.Queries.GetDevicesCurrentValues;

public sealed class GetDevicesCurrentValuesQuery : IQuery<GetDevicesCurrentValuesQueryResult>
{
	public GetDevicesCurrentValuesQuery(string poolAlias)
	{
		PoolAlias = poolAlias;
	}

	public string PoolAlias { get; }
}