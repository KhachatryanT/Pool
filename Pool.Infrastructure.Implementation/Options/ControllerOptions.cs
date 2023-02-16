using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Pool.Entities.Enums;

namespace Pool.Infrastructure.Implementation.Options;

internal sealed class ControllerOptions
{
	/// <summary>
	/// Тип контроллера
	/// </summary>
	public ControllerType Type { get; [UsedImplicitly] init; }

	/// <summary>
	/// Код контроллера
	/// </summary>
	/// <remarks>
	/// Уникальный код контроллера
	/// </remarks>
	[Required]
	public string Code { get; [UsedImplicitly] init; } = default!;

	/// <summary>
	/// Группа контролеера
	/// </summary>
	[Required]
	public string Group { get; init; } = default!;
	
	/// <summary>
	/// Адрес доступа в сети RS-485
	/// </summary>
	[Required]
	[Range(1,15)]
	public int Address { get; init; }

	/// <summary>
	/// Устройства, сенсоры контроллера
	/// </summary>
	public DeviceOptions[] Devices { get; [UsedImplicitly] init; } = Array.Empty<DeviceOptions>();
}