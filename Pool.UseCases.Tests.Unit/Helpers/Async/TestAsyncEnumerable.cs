using System.Linq.Expressions;

namespace Pool.UseCases.Tests.Unit.Helpers.Async;

internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
{
	public TestAsyncEnumerable(Expression expression)
		: base(expression)
	{
	}

	IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<T>(this);

	IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken) =>
		new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
}