using Datacenter.Domain.Primitives;

namespace Datacenter.Domain.Exceptions;

public class RackBusyPositionDomainException : DomainException
{
    public RackBusyPositionDomainException()
        : base("Posicao do rack ja esta ocupada")
    {
    }
}
