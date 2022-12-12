using FluentValidation;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.CQRS.CommonValidators;

internal sealed class IsPoolExistsValidator : AbstractValidator<string>
{
	public IsPoolExistsValidator(IPoolService poolService)
	{
		RuleFor(request => request)
			.MustAsync(poolService.IsPoolExistsAsync)
			.WithMessage("Не найден бассейн с псевдонимом \"{PropertyValue}\"");
	}
}