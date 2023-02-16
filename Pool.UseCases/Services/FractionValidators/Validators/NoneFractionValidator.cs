namespace Pool.UseCases.Services.FractionValidators.Validators;

internal sealed class NoneFractionValidator : IFractionValidator
{
	public bool IsValid(DateTimeOffset date) => true;
}