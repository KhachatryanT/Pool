namespace Pool.UseCases.Dto;

internal sealed class NormalizedIntervalIndicatorSummaryDto
{
	public NormalizedIntervalIndicatorSummaryDto(int scale, IEnumerable<NormalizedIntervalIndicatorDto> items)
	{
		Scale = scale;
		Items = items;
	}

	public int Scale { get; }
	public IEnumerable<NormalizedIntervalIndicatorDto> Items { get; }
}