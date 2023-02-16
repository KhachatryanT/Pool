using MediatR;

namespace Pool.UseCases;

public interface IQuery<out T> : IRequest<T>
{
}