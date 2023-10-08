using Datacenter.Domain.Exceptions;
using Datacenter.Domain.Primitives;

namespace Datacenter.Domain.Entities;

public sealed class DatacenterRoom : AggregateRoot
{
    public string Name { get; private set; }
    public int MaxRacks { get; private set; }
    public List<Rack> Racks { get; private set; }

    public DatacenterRoom(Guid id, string name, int maxRacks)
        : base(id)
    {
        Name = name;
        MaxRacks = maxRacks;
        Racks = new List<Rack>();
    }

    public void AddRack(Rack rack)
    {
        if (Racks.Count >= MaxRacks)
            throw new MaxRacksDomainException();

        Racks.Add(rack);
    }
}
