﻿using Pool.DevicesControllers.Abstractions.Models;

namespace Pool.DevicesControllers.Abstractions.Services;

public interface IDevicesService
{
	/// <summary>
	/// Получить показатели всех устройств
	/// </summary>
	/// <param name="poolAlias"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IReadOnlyCollection<DeviceIndicator>> GetDevicesAsync(string poolAlias, CancellationToken cancellationToken);
}