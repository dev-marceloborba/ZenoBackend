using Datacenter.Domain.Shared;
using MediatR;

namespace Datacenter.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}