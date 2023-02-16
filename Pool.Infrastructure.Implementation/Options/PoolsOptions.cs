using JetBrains.Annotations;

namespace Pool.Infrastructure.Implementation.Options;

internal sealed class PoolsOptions
{
	public PoolConfigurationOptions[] Pools { get; [UsedImplicitly] init; } = Array.Empty<PoolConfigurationOptions>();
}