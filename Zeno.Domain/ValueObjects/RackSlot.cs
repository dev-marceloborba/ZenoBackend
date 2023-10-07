using Datacenter.Domain.Primitives;

namespace Datacenter.Domain.ValueObjects;

public record RackSlot(int InitialPosition, int FinalPosition) : ValueObject
{
    public int GetSize() => FinalPosition - InitialPosition;
}
