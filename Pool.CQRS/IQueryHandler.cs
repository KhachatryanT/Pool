using MediatR;

namespace Pool.CQRS;

internal interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
	where TQuery : IQuery<TResult>
{
}