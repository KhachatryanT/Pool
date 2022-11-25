using FluentValidation;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.CQRS.CommonValidators;

internal sealed class IsPoolExistsValidator : AbstractValidator<string>
{
	public IsPoolExistsValidator(IPoolManager poolManager)
	{
		RuleFor(request => request)
			.MustAsync(poolManager.IsPoolExistsAsync)
			.WithMessage("Не найден бассейн с псевдонимом \"{PropertyValue}\"");
	}
}