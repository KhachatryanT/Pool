namespace Pool.DevicesControllers.Abstractions.Models;

public sealed class PoolInfo
{
	public PoolInfo(string? name, string alias)
	{
		Name = name;
		Alias = alias;
	}

	public string? Name { get; }
	public string Alias { get; }
}