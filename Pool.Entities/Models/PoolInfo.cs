namespace Pool.Entities.Models;

public sealed class PoolInfo
{
	public PoolInfo(string? name, string alias, ControllerInfo[] controllers)
	{
		Name = name;
		Alias = alias;
		Controllers = controllers;
	}

	// ReSharper disable once MemberCanBePrivate.Global
	public string? Name { get; }
	public string Alias { get; }

	/// <summary>
	/// Подключенные контроллеры
	/// </summary>
	// ReSharper disable once MemberCanBePrivate.Global
	public ControllerInfo[] Controllers { get; }
}