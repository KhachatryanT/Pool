﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Pool.Api.Hosting.Application;

/// <summary>
/// Фикс для отображения Enum в строковом представлении для 
/// </summary>
public class EnumSchemaFilter : ISchemaFilter
{
	public void Apply(OpenApiSchema model, SchemaFilterContext context)
	{
		if (context.Type.IsEnum)
		{
			model.Type = "string";
			model.Enum.Clear();
			Enum.GetNames(context.Type)
				.ToList()
				.ForEach(n => model.Enum.Add(new OpenApiString(n)));
		}
	}
}