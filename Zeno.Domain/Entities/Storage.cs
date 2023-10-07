using Datacenter.Domain.ValueObjects;

namespace Datacenter.Domain.Entities;

public sealed class Storage : RackEquipment
{
    public Storage(Guid id, string name, RackSlot rackSlot, double power) : base(id, name, rackSlot, power)
    {
    }
}
