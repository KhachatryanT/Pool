using FluentValidation;
using JetBrains.Annotations;
using Pool.CQRS.CommonValidators;
using Pool.DevicesControllers.Abstractions.Services;

namespace Pool.CQRS.Queries.GetDevicesHistory;

[UsedImplicitly]
public sealed class GetDevicesHistoryQueryValidator : AbstractValidator<GetDevicesHistoryQuery>
{
	public GetDevicesHistoryQueryValidator(IPoolService poolService)
	{
		ClassLevelCascadeMode = CascadeMode.Stop;
			
		RuleFor(query => query.PoolAlias)
			.NotEmpty()
			.WithMessage("Псевдоним бассейна не может быть пустым");

		RuleFor(query => query.PoolAlias)
			.SetValidator(new IsPoolExistsValidator(poolService));

		RuleFor(query => query)
			.Must(query => query.EndDate >= query.StartDate)
			.WithMessage("Дата окончания не может быть меньше даты начала");
	}
}