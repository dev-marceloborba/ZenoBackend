using Datacenter.Domain.Primitives;

namespace Datacenter.Domain.Exceptions;

public class MaxRacksDomainException : DomainException
{
    public MaxRacksDomainException() : base("O numero maximo de racks permitido foi atingido")
    {
    }
}
