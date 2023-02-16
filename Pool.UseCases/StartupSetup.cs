using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pool.UseCases.PipelineBehavior;
using Pool.UseCases.Services;
using Pool.UseCases.Services.Interfaces;

namespace Pool.UseCases;

public static class StartupSetup
{
	// ReSharper disable once InconsistentNaming
	public static IServiceCollection AddUseCases(this IServiceCollection services)
	{
		var assembly = typeof(StartupSetup).Assembly;
		services.AddMediatR(assembly);
		services.AddValidatorsFromAssembly(assembly);
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		services.AddSingleton<IFractionValidatorFactory, FractionValidatorFactory>();
		services.AddSingleton<IFractionExtractorFactory, FractionExtractorFactory>();
		return services;
	}
}