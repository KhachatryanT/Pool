using Pool.Entities.Models;

namespace Pool.UseCases.Handlers.Devices.Queries.GetDeviceHistory;

public sealed class GetDeviceHistoryQueryResult
{
	public GetDeviceHistoryQueryResult(IEnumerable<IndicatorsInInterval> items)
	{
		Items = items;
	}

	/// <summary>
	/// Элементы значений в интервалах
	/// </summary>
	public IEnumerable<IndicatorsInInterval> Items { get; }
}