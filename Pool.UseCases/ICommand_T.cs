using MediatR;

namespace Pool.UseCases;

internal interface ICommand<out T> : IRequest<T>
{

}