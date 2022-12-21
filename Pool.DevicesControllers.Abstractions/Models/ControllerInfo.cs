using Pool.Domain.Enums;

namespace Pool.DevicesControllers.Abstractions.Models;

public sealed class ControllerInfo
{
	public ControllerInfo(string code, IReadOnlyCollection<DeviceType> devices)
	{
		Code = code;
		Devices = devices;
	}

	public string Code { get; }
	public IReadOnlyCollection<DeviceType> Devices { get; }
}