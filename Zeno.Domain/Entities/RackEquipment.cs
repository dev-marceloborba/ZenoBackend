using Datacenter.Domain.Enums;
using Datacenter.Domain.Primitives;
using Datacenter.Domain.ValueObjects;

namespace Datacenter.Domain.Entities;

public abstract class RackEquipment : Entity
{
    public string Name { get; private set; }
    public double Power { get; private set; }
    public RackSlot RackSlot { get; set; }
    public ERackEquipmentStatus Status { get; private set; }

    protected RackEquipment(Guid id, string name, RackSlot rackSlot, double power)
        : base(id)
    {
        Name = name;
        RackSlot = rackSlot;
        Status = ERackEquipmentStatus.NOT_INSTALLED;
        Power = power;
    }
}
