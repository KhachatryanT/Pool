using FluentValidation;
using JetBrains.Annotations;
using Pool.CQRS.CommonValidators;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.CQRS.Queries.GetSensors;

[UsedImplicitly]
public sealed class GetSensorsQueryValidator : AbstractValidator<GetSensorsQuery>
{
	public GetSensorsQueryValidator(IPoolService poolService)
	{
		ClassLevelCascadeMode = CascadeMode.Stop;
			
		RuleFor(query => query.PoolAlias)
			.NotEmpty()
			.WithMessage("Псевдоним бассейна не может быть пустым");

		RuleFor(query => query.PoolAlias)
			.SetValidator(new IsPoolExistsValidator(poolService));
	}
}