using Datacenter.Domain.Primitives;

namespace Datacenter.Domain.Entities;

public sealed class DatacenterRoom : Entity
{
    public string Name { get; private set; }
    public List<Rack> Racks { get; private set; }

    public DatacenterRoom(Guid id, string name)
        : base(id)
    {
        Name = name;
        Racks = new List<Rack>();
    }

    public void AddRack(Rack rack) => Racks.Add(rack);
}
