using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Pool.DevicesControllers.Abstractions.Models;

namespace Pool.DevicesControllers.Settings;

internal sealed class ControllerSettings
{
	/// <summary>
	/// Тип контроллера
	/// </summary>
	// ReSharper disable once UnusedAutoPropertyAccessor.Global
	public ControllerType Type { get; init; }
	
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
	public DeviceSettings[] Devices { get; [UsedImplicitly] init; } = Array.Empty<DeviceSettings>();
}