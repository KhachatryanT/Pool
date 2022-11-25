using JetBrains.Annotations;

namespace Pool.DevicesControllers.Settings;

internal sealed class PoolsSettings
{
	public PoolConfigurationSettings[] Pools { get; [UsedImplicitly] init; } = Array.Empty<PoolConfigurationSettings>();
}