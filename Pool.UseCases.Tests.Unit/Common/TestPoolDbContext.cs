using Moq;
using Pool.Entities.Enums;
using Pool.Entities.Models;
using Pool.Infrastructure.Interfaces.DataAccess;
using Pool.UseCases.Tests.Unit.Helpers;

namespace Pool.UseCases.Tests.Unit.Common;

internal static class TestPoolDbContext
{
	public static IDbContext CreateContext()
	{
		var poolIndicatorsMockSet = new PoolIndicator[]
			{
				// Ph
				new()
				{
					Id = 100,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:00:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Ph,
					Value = 8
				},
				new()
				{
					Id = 101,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("05.01.2023 01:05:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Ph,
					Value = 7.1
				},
				new()
				{
					Id = 102,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("10.01.2023 01:10:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Ph,
					Value = 7
				},
				new()
				{
					Id = 103,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("15.01.2023 01:15:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Ph,
					Value = 6.9
				},
				new()
				{
					Id = 104,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("17.01.2023 01:20:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Ph,
					Value = 6.9
				},
				new()
				{
					Id = 105,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("18.01.2023 01:25:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Ph,
					Value = 6.9
				},
				new()
				{
					Id = 106,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("29.12.2022 00:00:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Ph,
					Value = 7
				},
				new()
				{
					Id = 107,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("26.12.2022 01:00:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Ph,
					Value = 7.5
				},
				new()
				{
					Id = 108,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("16.12.2022 01:00:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Ph,
					Value = 7.7
				},
				// Cl
				new()
				{
					Id = 200,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:00:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Cl,
					Value = 1.5
				},
				new()
				{
					Id = 201,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:05:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Cl,
					Value = 0.6
				},
				new()
				{
					Id = 202,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:10:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Cl,
					Value = 0.5
				},
				new()
				{
					Id = 203,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:15:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Cl,
					Value = 0.4
				},
				new()
				{
					Id = 204,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:20:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Cl,
					Value = 0.3
				},
				new()
				{
					Id = 205,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:25:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Cl,
					Value = 0.2
				},
				// Rx
				new()
				{
					Id = 300,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:00:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Rx,
					Value = 900
				},
				new()
				{
					Id = 301,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:05:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Rx,
					Value = 500
				},
				new()
				{
					Id = 302,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:10:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Rx,
					Value = 450
				},
				new()
				{
					Id = 303,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:15:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Rx,
					Value = 400
				},
				new()
				{
					Id = 304,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:20:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Rx,
					Value = 350
				},
				new()
				{
					Id = 305,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:25:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Rx,
					Value = 300
				},
				// Temp
				new()
				{
					Id = 400,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:00:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Temp,
					Value = 24
				},
				new()
				{
					Id = 401,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:05:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Temp,
					Value = 24
				},
				new()
				{
					Id = 402,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:10:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Temp,
					Value = 25
				},
				new()
				{
					Id = 403,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:15:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Temp,
					Value = 26
				},
				new()
				{
					Id = 404,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:20:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Temp,
					Value = 25
				},
				new()
				{
					Id = 405,
					ControllerCode = "controller 1",
					Date = DateTimeOffset.Parse("01.01.2023 01:25:00 +03:00"),
					PoolAlias = "pool 1",
					Type = DeviceType.Temp,
					Value = 27
				}
			}.AsQueryable()
			.BuildMockDbSet();

		var mockContext = new Mock<IDbContext>();
		mockContext.Setup(x => x.PoolIndicators).Returns(poolIndicatorsMockSet);
		mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

		return mockContext.Object;
	}
}