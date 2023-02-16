using MediatR;

namespace Pool.UseCases;

internal interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
	where TQuery : IQuery<TResult>
{
}