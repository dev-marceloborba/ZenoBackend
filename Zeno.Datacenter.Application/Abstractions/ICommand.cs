using Datacenter.Domain.Primitives;
using MediatR;

namespace Datacenter.Application.Abstractions;

public interface ICommand<TResponse> : IRequest<Result<TResponse, DomainException>>
{
}
