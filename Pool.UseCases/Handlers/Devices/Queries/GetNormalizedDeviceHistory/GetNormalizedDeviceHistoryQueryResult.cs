using Pool.Entities.Models;

namespace Pool.UseCases.Handlers.Devices.Queries.GetNormalizedDeviceHistory;

public sealed class GetNormalizedDeviceHistoryQueryResult
{
	public GetNormalizedDeviceHistoryQueryResult(IEnumerable<NormalizationScale> scales, IEnumerable<NormalizedIndicatorsInInterval> items)
	{
		Scales = scales;
		Items = items;
	}

	/// <summary>
	/// Масштабы показателей устройств
	/// </summary>
	public IEnumerable<NormalizationScale> Scales { get; }
	
	/// <summary>
	/// Элементы значений в интервалах
	/// </summary>
	public IEnumerable<NormalizedIndicatorsInInterval> Items { get; }
}