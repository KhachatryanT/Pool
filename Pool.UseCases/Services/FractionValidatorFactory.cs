using Pool.Entities.Enums;
using Pool.UseCases.Services.FractionValidators;
using Pool.UseCases.Services.FractionValidators.Validators;
using Pool.UseCases.Services.Interfaces;

namespace Pool.UseCases.Services;

internal sealed class FractionValidatorFactory : IFractionValidatorFactory
{
	public IFractionValidator CreateValidator(FractionType type)
		=> type switch
		{
			FractionType.None => new NoneFractionValidator(),
			FractionType.Hour => new HourFractionValidator(),
			FractionType.Hour4 => new Hour4FractionValidator(),
			FractionType.Day => new DayFractionValidator(),
			FractionType.Week => new WeekFractionValidator(),
			FractionType.Month => new MonthFractionValidator(),
			_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
		};
}