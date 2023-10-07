namespace Datacenter.Domain.Primitives;

public abstract class DomainException : Exception
{
    protected DomainException(string error)
        : base(error)
    { }
}
