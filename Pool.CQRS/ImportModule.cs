using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Pool.CQRS.PipelineBehavior;

namespace Pool.CQRS;

public static class ImportModule
{
	// ReSharper disable once InconsistentNaming
	public static IServiceCollection AddCQRS(this IServiceCollection services)
	{
		var assembly = typeof(ImportModule).Assembly;
		services.AddMediatR(assembly);
		services.AddValidatorsFromAssembly(assembly);
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		return services;
	}
}