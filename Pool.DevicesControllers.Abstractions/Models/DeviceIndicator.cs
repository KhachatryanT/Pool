using Pool.Domain.Enums;

namespace Pool.DevicesControllers.Abstractions.Models;

/// <summary>
/// Показатели устройства
/// </summary>
public class DeviceIndicator
{
	public DeviceIndicator(string poolAlias, string controllerCode, DeviceType type, DateTimeOffset date, double value)
	{
		PoolAlias = poolAlias;
		ControllerCode = controllerCode;
		Type = type;
		Date = date;
		Value = value;
	}

	/// <summary>
	/// Превдоним бассейна
	/// </summary>
	public string PoolAlias { get; }

	/// <summary>
	/// Код контроллера
	/// </summary>
	public string ControllerCode { get; }

	/// <summary>
	/// Тип устройства
	/// </summary>
	public DeviceType Type { get; }

	/// <summary>
	/// Дата получения значения
	/// </summary>
	public DateTimeOffset Date { get; }

	/// <summary>
	/// Значение
	/// </summary>
	public double Value { get; }
}