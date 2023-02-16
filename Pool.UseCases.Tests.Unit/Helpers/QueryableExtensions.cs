using Microsoft.EntityFrameworkCore;
using Moq;
using Pool.UseCases.Tests.Unit.Helpers.Async;

namespace Pool.UseCases.Tests.Unit.Helpers;

internal static class QueryableExtensions
{
	public static DbSet<T> BuildMockDbSet<T>(this IQueryable<T> source)
		where T : class
	{
		var mock = new Mock<DbSet<T>>();
		mock.As<IAsyncEnumerable<T>>()
			.Setup(x => x.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
			.Returns(new TestAsyncEnumerator<T>(source.GetEnumerator()));

		mock.As<IQueryable<T>>()
			.Setup(x => x.Provider)
			.Returns(new TestAsyncQueryProvider<T>(source.Provider));

		mock.As<IQueryable<T>>()
			.Setup(x => x.Expression)
			.Returns(source.Expression);

		mock.As<IQueryable<T>>()
			.Setup(x => x.ElementType)
			.Returns(source.ElementType);

		mock.As<IQueryable<T>>()
			.Setup(x => x.GetEnumerator())
			.Returns(source.GetEnumerator());

		return mock.Object;
	}
}