using MediatR;

namespace Pool.CQRS;

public interface IQuery<out T> : IRequest<T>
{
}