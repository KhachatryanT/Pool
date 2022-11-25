using MediatR;

namespace Pool.CQRS;

public interface ICommand<out T> : IRequest<T>
{

}