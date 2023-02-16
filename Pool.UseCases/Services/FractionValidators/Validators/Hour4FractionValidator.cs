namespace Pool.UseCases.Services.FractionValidators.Validators;

internal sealed class Hour4FractionValidator : IFractionValidator
{
	public bool IsValid(DateTimeOffset date)
	{
		return date.Millisecond == 0 &&
		       date.Second == 0 &&
		       date.Minute == 0 &&
		       date.Hour % 4 == 0;
	}
}