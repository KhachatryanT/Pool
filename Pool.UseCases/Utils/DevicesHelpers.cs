using Pool.Entities.Enums;

namespace Pool.UseCases.Utils;

internal static class DevicesHelpers
{
	public static double? WithPrecision(this double? value, DeviceType type)
		=> !value.HasValue ? null : WithPrecision(value.Value, type);

	public static double WithPrecision(this double value, DeviceType type) =>
		WithPrecision(value, DevicePrecision(type));
	
	public static double? WithPrecision(this double? value, int precision)
		=> !value.HasValue ? null : WithPrecision(value.Value, precision);
	
	public static double WithPrecision(this double value, int precision)=>
		Math.Round(value, precision);

	/// <summary>
	/// Точность типа устройства
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public static int DevicePrecision(DeviceType type) =>
		type switch
		{
			DeviceType.Ph => 2,
			DeviceType.Cl => 2,
			DeviceType.Rx => 0,
			DeviceType.Temp => 1,
			_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
		};
}