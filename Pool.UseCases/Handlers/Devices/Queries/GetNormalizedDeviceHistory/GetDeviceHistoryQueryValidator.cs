using FluentValidation;
using JetBrains.Annotations;
using Pool.Infrastructure.Interfaces.Services;
using Pool.UseCases.Handlers.CommonValidators;
using Pool.UseCases.Services.Interfaces;

namespace Pool.UseCases.Handlers.Devices.Queries.GetNormalizedDeviceHistory;

[UsedImplicitly]
public sealed class GetDeviceHistoryQueryValidator : AbstractValidator<GetNormalizedDeviceHistoryQuery>
{
	public GetDeviceHistoryQueryValidator(IPoolService poolService, IFractionValidatorFactory fractionValidatorFactory)
	{
		ClassLevelCascadeMode = CascadeMode.Stop;

		RuleFor(query => query.PoolAlias)
			.NotEmpty()
			.WithMessage("Псевдоним бассейна не может быть пустым");

		RuleFor(query => query.PoolAlias)
			.SetValidator(new IsPoolExistsValidator(poolService));

		RuleFor(query => query)
			.Must(query => query.EndDate >= query.StartDate)
			.WithMessage("Дата окончания не может быть меньше или равна дате начала");

		RuleFor(query => query)
			.Must(query =>
			{
				var fractionValidator = fractionValidatorFactory.CreateValidator(query.FractionType);
				return fractionValidator.IsValid(query.StartDate);
			})
			.WithMessage("Недопустимая дата начала или окончания для типа фракции");
	}
}