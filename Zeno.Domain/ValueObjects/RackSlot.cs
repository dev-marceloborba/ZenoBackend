namespace Datacenter.Domain.ValueObjects;

public record RackSlot(int InitialPosition, int FinalPosition)
{
    public int GetSize() => FinalPosition - InitialPosition;
}
