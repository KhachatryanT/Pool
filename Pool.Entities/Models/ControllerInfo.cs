using Pool.Entities.Enums;

namespace Pool.Entities.Models;

public sealed class ControllerInfo
{
	public ControllerInfo(string code, IEnumerable<DeviceType> devices)
	{
		Code = code;
		Devices = devices;
	}

	public string Code { get; }
	public IEnumerable<DeviceType> Devices { get; }
}