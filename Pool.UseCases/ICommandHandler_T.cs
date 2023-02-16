using MediatR;

namespace Pool.UseCases;

internal interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
	where TCommand : ICommand<TResult>
{
}