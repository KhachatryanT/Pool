using FluentValidation;
using JetBrains.Annotations;
using Pool.Infrastructure.Interfaces.Services;
using Pool.UseCases.Handlers.CommonValidators;

namespace Pool.UseCases.Handlers.Devices.Queries.GetDevicesCurrentValues;

[UsedImplicitly]
public sealed class GetDevicesCurrentValuesQueryValidator : AbstractValidator<GetDevicesCurrentValuesQuery>
{
	public GetDevicesCurrentValuesQueryValidator(IPoolService poolService)
	{
		ClassLevelCascadeMode = CascadeMode.Stop;
			
		RuleFor(query => query.PoolAlias)
			.NotEmpty()
			.WithMessage("Псевдоним бассейна не может быть пустым");

		RuleFor(query => query.PoolAlias)
			.SetValidator(new IsPoolExistsValidator(poolService));
	}
}