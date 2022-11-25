namespace Pool.DevicesControllers.Abstractions.Models;

/// <summary>
/// Показатели устройства
/// </summary>
public class DeviceIndicator
{
	public DeviceIndicator(string poolAlias, string controllerCode)
	{
		PoolAlias = poolAlias;
		ControllerCode = controllerCode;
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
	/// Текущие показатели устройства
	/// </summary>
	public DeviceValue? CurrentValue { get; init; }
}