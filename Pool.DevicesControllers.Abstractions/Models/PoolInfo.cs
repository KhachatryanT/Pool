namespace Pool.DevicesControllers.Abstractions.Models;

public sealed class PoolInfo
{
	public PoolInfo(string? name, string alias, ControllerInfo[] controllers)
	{
		Name = name;
		Alias = alias;
		Controllers = controllers;
	}

	public string? Name { get; }
	public string Alias { get; }

	/// <summary>
	/// Подключенные контроллеры
	/// </summary>
	public ControllerInfo[] Controllers { get; }
}