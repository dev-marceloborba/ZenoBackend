using Datacenter.Domain.Primitives;

namespace Datacenter.Domain.Exceptions;

public class RackUnavailableSpaceDomainException : DomainException
{
    public RackUnavailableSpaceDomainException()
        : base("Espaco disponivel no rack incompativel com tamanho do equipamento")
    {
    }
}
