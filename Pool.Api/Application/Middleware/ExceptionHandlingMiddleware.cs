﻿using System.Text.Json;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Diagnostics;
using Pool.Domain.Exceptions;

namespace Pool.Api.Application.Middleware;

internal static class ExceptionHandlingMiddlewareExtension
{
	public static IApplicationBuilder UsePoolExceptionHandling(this IApplicationBuilder app)
	{
		app.UseExceptionHandler(appError =>
		{
			appError.Run(async context =>
			{
				var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
				if (contextFeature is null)
				{
					return;
				}

				var exception = contextFeature.Error;
				var statusCode = GetStatusCode(exception);
				var response = new
				{
					status = statusCode,
					title = GetTitle(exception),
					message = GetMessage(exception),
					details = GetErrors(exception)
				};
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = statusCode;
				await context.Response.WriteAsync(JsonSerializer.Serialize(response));
			});
		});

		return app;
	}

	private static int GetStatusCode(Exception exception) =>
		exception switch
		{
			NotFoundException => StatusCodes.Status404NotFound,
			ValidationException => StatusCodes.Status400BadRequest,
			_ => StatusCodes.Status500InternalServerError
		};

	private static string GetTitle(Exception exception) =>
		exception switch
		{
			NotFoundException _ => "Не найдено",
			ValidationException _ => "Ошибки валидации",
			_ => "Server Error"
		};

	private static string GetMessage(Exception exception) =>
		exception switch
		{
			NotFoundException e => e.Message,
			ValidationException e => string.Join("; ", e.Errors.Select(x => x.ErrorMessage)),
			_ => "Server Error"
		};

	private static IReadOnlyCollection<ValidationFailure> GetErrors(Exception exception)
	{
		if (exception is ValidationException validationException)
		{
			return validationException.Errors.ToArray();
		}

		return Array.Empty<ValidationFailure>();
	}
}