namespace Pool.UseCases.Services.FractionValidators.Validators;

internal sealed class MonthFractionValidator : IFractionValidator
{
	public bool IsValid(DateTimeOffset date)
	{
		return date.Millisecond == 0 &&
		       date.Second == 0 &&
		       date.Minute == 0 &&
		       date.Hour == 0 &&
		       date.Day == 1;
	}
}