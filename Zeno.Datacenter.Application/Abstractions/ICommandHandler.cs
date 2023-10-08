using Datacenter.Domain.Primitives;
using MediatR;

namespace Datacenter.Application.Abstractions;

public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse, DomainException>>
    where TCommand : ICommand<TResponse>
{
}
