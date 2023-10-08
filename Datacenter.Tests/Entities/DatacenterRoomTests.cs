using Datacenter.Domain.Entities;
using Datacenter.Domain.Exceptions;

namespace Datacenter.Tests.Entities;

public class DatacenterRoomTests
{
    [Fact]
    public void Should_Add_Two_Racks()
    {
        var datacenterRoom = new DatacenterRoom(Guid.NewGuid(), "Piso 1", 80);
        var rack1 = new Rack(Guid.NewGuid(), "Rack1", "A2:H4", 42, 4000);
        var rack2 = new Rack(Guid.NewGuid(), "Rack2", "A3:H5", 42, 4000);

        datacenterRoom.AddRack(rack1);
        datacenterRoom.AddRack(rack2);

        Assert.Equal(2, datacenterRoom.Racks.Count);
    }

    [Fact]
    public void Should_Return_Exception_When_Exceeding_Max_Racks()
    {
        var datacenterRoom = new DatacenterRoom(Guid.NewGuid(), "Piso 1", 2);
        var rack1 = new Rack(Guid.NewGuid(), "Rack1", "A2:H4", 42, 4000);
        var rack2 = new Rack(Guid.NewGuid(), "Rack2", "A3:H4", 42, 4000);
        var rack3 = new Rack(Guid.NewGuid(), "Rack3", "A4:H4", 42, 4000);

        datacenterRoom.AddRack(rack1);
        datacenterRoom.AddRack(rack2);

        Action action = () => datacenterRoom.AddRack(rack3);
        var exception = Record.Exception(action);

        Assert.IsType<MaxRacksDomainException>(exception);
    }
}
