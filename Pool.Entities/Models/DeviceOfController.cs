namespace Pool.Entities.Models;

/// <summary>
/// Устройство контроллера
/// </summary>
public sealed class DeviceOfController
{
	public DeviceOfController(string controller, IndicatorOfDevice device)
	{
		Controller = controller;
		Device = device;
	}

	public string Controller { get; }
	public IndicatorOfDevice Device { get; }
}