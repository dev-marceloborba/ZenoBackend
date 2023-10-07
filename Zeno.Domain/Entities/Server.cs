using Datacenter.Domain.ValueObjects;

namespace Datacenter.Domain.Entities;

public sealed class Server : RackEquipment
{
    public Server(Guid id, string name, RackSlot rackSlot, double power) : base(id, name, rackSlot, power)
    {
    }
}
