using MediatR;

namespace Pool.CQRS;

internal interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
	where TCommand : ICommand
{
}