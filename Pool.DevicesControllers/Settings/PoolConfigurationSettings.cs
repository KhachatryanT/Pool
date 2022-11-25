using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace Pool.DevicesControllers.Settings;

internal sealed class PoolConfigurationSettings
{
	public string? Name { get; init; }
	/// <summary>
	/// Псевдоним бассейна
	/// </summary>
	public string Alias { get; [UsedImplicitly] init; } = default!;
	
	/// <summary>
	/// Адрес доступа в сети RS-485
	/// </summary>
	[Required]
	[Range(1,15)]
	public int Address { get; init; }

	/// <summary>
	/// Контроллеры
	/// </summary>
	public ControllerSettings[] Controllers { get; [UsedImplicitly] init; } = Array.Empty<ControllerSettings>();
}