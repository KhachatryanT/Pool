using FluentValidation;
using Pool.Infrastructure.Interfaces.Services;

namespace Pool.UseCases.Handlers.CommonValidators;

internal sealed class IsPoolExistsValidator : AbstractValidator<string>
{
	public IsPoolExistsValidator(IPoolService poolService)
	{
		RuleFor(request => request)
			.MustAsync(poolService.IsPoolExistsAsync)
			.WithMessage("Не найден бассейн с псевдонимом \"{PropertyValue}\"");
	}
}