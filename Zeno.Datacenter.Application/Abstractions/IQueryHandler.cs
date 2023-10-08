using Datacenter.Domain.Primitives;
using MediatR;

namespace Datacenter.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse, DomainException>>
    where TQuery : IQuery<TResponse>
{
}
