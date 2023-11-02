using Datacenter.Domain.Exceptions;
using Datacenter.Domain.Primitives;

namespace Datacenter.Domain.Entities;

public sealed class Rack : Entity
{
    public string Name { get; private set; }
    public double PowerCapacity { get; private set; }
    public int Capacity { get; set; }
    public string Localization { get; private set; }
    public List<RackEquipment> RackEquipments { get; private set; }

    public Rack(Guid id, string name, string localization, int capacity, double powerCapacity)
        : base(id)
    {
        Name = name;
        Localization = localization;
        RackEquipments = new List<RackEquipment>();
        Capacity = capacity;
        PowerCapacity = powerCapacity;
    }

    public void PlaceEquipment(RackEquipment equipment)
    {
        if (RackEquipments.Exists(re => re.RackSlot.InitialPosition <= equipment.RackSlot.InitialPosition &&
            re.RackSlot.FinalPosition >= equipment.RackSlot.FinalPosition)) 
        {
            throw new RackBusyPositionDomainException();
        }

        if (GetAvailableSpace() < (equipment.RackSlot.GetSize()))
        {
            throw new RackUnavailableSpaceDomainException();
        }

        if (equipment.Power > GetAvailablePower())
        {
            throw new RackUnavailableSpaceDomainException();
        }

        if (RackEquipments.Count == 0)
        {
            RackEquipments.Add(equipment);
            return;
        }

        for (int i = 1; i <= Capacity; i++)
        {
            var currentSlot = RackEquipments.FirstOrDefault(equipment => 
                equipment.RackSlot.InitialPosition == i || equipment.RackSlot.FinalPosition >= i);

            if (currentSlot is null)
            {
                RackEquipments.Add(equipment);
                break;
            }
        }
    }

    public void RemoveEquipment(RackEquipment equipment) => RackEquipments.Remove(equipment);
    public int GetAvailableSpace() => Capacity - RackEquipments.Sum(re => re.RackSlot.GetSize() + 1);
    public double GetAvailablePower() => PowerCapacity - RackEquipments.Sum(re => re.Power);
}
