using Pool.Entities.Models;

namespace Pool.Infrastructure.DevicesControllers.Fake.Models;

public sealed class TempDetails : IndicatorDetailsBase
{
	public string TempValue = "Some temp details. Ignore Details property.";
}