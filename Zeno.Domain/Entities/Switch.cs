using Datacenter.Domain.ValueObjects;

namespace Datacenter.Domain.Entities;

public sealed class Switch : RackEquipment
{
    public Switch(Guid id, string name, RackSlot rackSlot, double power) : base(id, name, rackSlot, power)
    {
    }
}
