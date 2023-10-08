using Datacenter.Domain.Exceptions;
using Datacenter.Domain.Primitives;

namespace Datacenter.Domain.ValueObjects;

public class RackSlot : ValueObject
{
    public int InitialPosition { get; private set; }
    public int FinalPosition { get; private set; }

    public RackSlot(int initialPosition, int finalPosition)
    {
        InitialPosition = initialPosition;
        FinalPosition = finalPosition;
        Validate();
    }

    private void Validate()
    {
        if (FinalPosition < InitialPosition)
        {
            throw new InvalidRackSlotDomainException();
        }
    }

    public int GetSize() => FinalPosition - InitialPosition;

    public override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}
