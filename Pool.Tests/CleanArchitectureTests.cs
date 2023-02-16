using System.Reflection;
using System.Runtime.Loader;

namespace Pool.Tests;

public class CleanArchitectureTests
{
	[Fact]
	public void CrossLayerReferences()
	{
		var wrongReferences = new List<(string From, string To)>
		{
			// nuget packages
			("Pool.Entities", "EntityFramework"),
			("Pool.Entities", "Pool"),

			//projects
			("Pool.UseCases", "Pool.DataAccess"),
			("Pool.UseCases", "Pool.Infrastructure.DevicesControllers"),
			("Pool.UseCases", "Pool.Infrastructure.Implementation"),

			("Pool.Controllers", "Pool.DataAccess"),
			("Pool.Controllers", "Pool.Infrastructure.Implementation"),
			("Pool.Controllers", "Pool.Infrastructure.DevicesControllers"),
			("Pool.Controllers", "Pool.WebUI"),

			("Pool.Infrastructure.Implementation", "Pool.Infrastructure.DevicesControllers"),
			("Pool.Infrastructure.Implementation", "Pool.DataAccess"),
			("Pool.Infrastructure.Implementation", "Pool.UseCases"),
		};

		var location = Assembly.GetExecutingAssembly().Location;
		var assemblies = Directory.EnumerateFiles(Path.GetDirectoryName(location)!, "Pool*.dll")
			.Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
			.ToArray();

		foreach (var wrongRef in wrongReferences)
		{
			foreach (var assembly in assemblies)
			{
				foreach (var reference in assembly.GetReferencedAssemblies())
				{
					Assert.False(assembly.FullName!.Contains(wrongRef.From) && reference.FullName.Contains(wrongRef.To),
						$"Cross-layer reference from '{assembly.FullName}' to '{reference.FullName}'");
				}
			}
		}
	}
}