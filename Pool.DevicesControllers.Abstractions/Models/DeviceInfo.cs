namespace Pool.DevicesControllers.Abstractions.Models;

public class DeviceInfo
{
	public DeviceInfo(string poolAlias, string controllerCode)
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