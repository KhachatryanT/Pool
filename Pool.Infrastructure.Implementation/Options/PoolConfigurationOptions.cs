using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace Pool.Infrastructure.Implementation.Options;

internal sealed class PoolConfigurationOptions
{
	public string? Name { get; [UsedImplicitly] init; }
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
	public ControllerOptions[] Controllers { get; [UsedImplicitly] init; } = Array.Empty<ControllerOptions>();
}