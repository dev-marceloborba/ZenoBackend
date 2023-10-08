using Datacenter.Domain.Primitives;

namespace Datacenter.Domain.Exceptions;

public class InvalidRackSlotDomainException : DomainException
{
    public InvalidRackSlotDomainException() : base("A posicao final deve ser maior que a posicao inicial do slot")
    {
    }
}
