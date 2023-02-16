using MediatR;

namespace Pool.UseCases;

internal interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
	where TCommand : ICommand
{
}