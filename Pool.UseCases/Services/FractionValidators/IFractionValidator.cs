namespace Pool.UseCases.Services.FractionValidators;

public interface IFractionValidator
{
	bool IsValid(DateTimeOffset date);
}