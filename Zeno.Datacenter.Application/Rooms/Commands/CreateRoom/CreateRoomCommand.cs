using Datacenter.Application.Abstractions;

namespace Datacenter.Application.DatacenterRoom.Commands.CreateDatacenterRoom;

public sealed record CreateRoomCommand(string Name, int MaxRacks): ICommand;
