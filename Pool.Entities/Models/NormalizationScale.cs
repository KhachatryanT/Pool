using Pool.Entities.Enums;

namespace Pool.Entities.Models;

public sealed class NormalizationScale
{
	public NormalizationScale(DeviceType type, int scale)
	{
		Type = type;
		Scale = scale;
	}

	public DeviceType Type { get; }
	public int Scale { get; }
}