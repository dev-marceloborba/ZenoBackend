using Datacenter.Domain.Entities;
using Datacenter.Domain.Exceptions;
using Datacenter.Domain.ValueObjects;

namespace Datacenter.Tests.Entities;

public class RackTests
{
    [Fact]
    public void Should_Create_Rack()
    {
        var rack = new Rack(Guid.NewGuid(), "Rack1", "A1-D1", 42, 4000.00);

        Assert.IsAssignableFrom<Rack>(rack);
    }

    [Fact]
    public void Space_Available_Should_Be_38()
    {
        var rack = new Rack(Guid.NewGuid(), "Rack1", "A1-D1", 42, 4000.00);
        var server = new Server(Guid.NewGuid(), "Server 1", new RackSlot(1,4), 30);

        rack.PlaceEquipment(server);

        Assert.Equal(38, rack.GetAvailableSpace());
    }

    [Fact]
    public void Should_Add_Two_Equipments()
    {
        var rack = new Rack(Guid.NewGuid(), "Rack1", "A1-D1", 42, 4000.00);
        var server1 = new Server(Guid.NewGuid(), "Server 1", new RackSlot(1, 4), 30);
        var server2 = new Server(Guid.NewGuid(), "Server 2", new RackSlot(5, 9), 30);


        rack.PlaceEquipment(server1);
        rack.PlaceEquipment(server2);

        Assert.Equal(2, rack.RackEquipments.Count);
    }

    [Fact]
    public void Should_Return_Exception_On_Adding_Two_Equipments_On_Same_Position()
    {
        var rack = new Rack(Guid.NewGuid(), "Rack1", "A1-D1", 42, 4000.00);
        var server1 = new Server(Guid.NewGuid(), "Server 1", new RackSlot(1, 4), 30);
        var server2 = new Server(Guid.NewGuid(), "Server 2", new RackSlot(1, 4), 30);

        rack.PlaceEquipment(server1);
        Action check = () => rack.PlaceEquipment(server2);

        var exception = Record.Exception(check);
        Assert.IsType<RackBusyPositionDomainException>(exception);
    }

    [Fact]
    public void Should_Return_Exception_On_Adding_Two_Equipments_On_Ocuppied_Position()
    {
        var rack = new Rack(Guid.NewGuid(), "Rack1", "A1-D1", 42, 4000.00);
        var server1 = new Server(Guid.NewGuid(), "Server 1", new RackSlot(1, 10), 30);
        var server2 = new Server(Guid.NewGuid(), "Server 2", new RackSlot(3, 7), 30);

        rack.PlaceEquipment(server1);
        Action check = () => rack.PlaceEquipment(server2);

        var exception = Record.Exception(check);
        Assert.IsType<RackBusyPositionDomainException>(exception);
    }

    [Fact]
    public void Should_Add_Three_Equipments_In_Random_Order()
    {
        var rack = new Rack(Guid.NewGuid(), "Rack1", "A1-D1", 42, 4000.00);
        var server1 = new Server(Guid.NewGuid(), "Server 1", new RackSlot(1, 2), 30);
        var server2 = new Server(Guid.NewGuid(), "Server 2", new RackSlot(5, 9), 30);
        var server3 = new Server(Guid.NewGuid(), "Server 3", new RackSlot(3, 4), 30);


        rack.PlaceEquipment(server1);
        rack.PlaceEquipment(server2);
        rack.PlaceEquipment(server3);

        Assert.Equal(3, rack.RackEquipments.Count);
    }

    [Fact]
    public void Should_Return_Exception_When_Adding_The_First_Equipment_On_Rack_With_Exceeded_Space()
    {
        var rack = new Rack(Guid.NewGuid(), "Rack1", "A1-D1", 42, 4000.00);
        var server1 = new Server(Guid.NewGuid(), "Server 1", new RackSlot(1, 80), 10);


        Action check = () => rack.PlaceEquipment(server1);
        var exception = Record.Exception(check);
        Assert.IsType<RackUnavailableSpaceDomainException>(exception);
    }

    [Fact]
    public void Should_Return_Exception_When_Adding_A_Equipment_With_The_Rack_At_Full_Capacity()
    {
        var rack = new Rack(Guid.NewGuid(), "Rack1", "A1-D1", 42, 4000.00);
        var server1 = new Server(Guid.NewGuid(), "Server 1", new RackSlot(1, 10), 10);
        var server2 = new Server(Guid.NewGuid(), "Server 2", new RackSlot(11, 44), 10);

        rack.PlaceEquipment(server1);

        Action check = () => rack.PlaceEquipment(server2);
        var exception = Record.Exception(check);
        Assert.IsType<RackUnavailableSpaceDomainException>(exception);
    }

    [Fact]
    public void Should_Return_Exception_When_Adding_A_Equipment_With_The_Rack_At_Full_Power()
    {
        var rack = new Rack(Guid.NewGuid(), "Rack1", "A1-D1", 42, 1000.00);
        var server1 = new Server(Guid.NewGuid(), "Server 1", new RackSlot(1, 2), 500);
        var server2 = new Server(Guid.NewGuid(), "Server 2", new RackSlot(3, 4), 500);
        var server3 = new Server(Guid.NewGuid(), "Server 3", new RackSlot(5, 6), 500);


        rack.PlaceEquipment(server1);
        rack.PlaceEquipment(server2);   

        Action check = () => rack.PlaceEquipment(server3);
        var exception = Record.Exception(check);
        Assert.IsType<RackUnavailableSpaceDomainException>(exception);
    }

    [Fact]
    public void Should_Return_Exception_When_Adding_A_Equipment_With_Wrong_Positions()
    {
        var rack = new Rack(Guid.NewGuid(), "Rack1", "A1-D1", 42, 1000.00);
        
        Action check = () => new Server(Guid.NewGuid(), "Server 1", new RackSlot(2, 1), 500);
        var exception = Record.Exception(check);

        Assert.IsType<InvalidRackSlotDomainException>(exception);
    }
}