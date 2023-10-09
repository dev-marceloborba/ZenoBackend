using Datacenter.Domain.Shared;
using MediatR;

namespace Datacenter.Application.Abstractions;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
