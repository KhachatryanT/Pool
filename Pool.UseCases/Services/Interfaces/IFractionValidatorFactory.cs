using Pool.Entities.Enums;
using Pool.UseCases.Services.FractionValidators;

namespace Pool.UseCases.Services.Interfaces;

public interface IFractionValidatorFactory
{
	IFractionValidator CreateValidator(FractionType type);
}