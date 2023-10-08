using Datacenter.Domain.Primitives;
using MediatR;

namespace Datacenter.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse, DomainException>>
{
}
