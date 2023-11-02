using Datacenter.Application.Abstractions;

namespace Datacenter.Application.Rooms.Commands.DeleteRoom;

public sealed record DeleteRoomCommand(Guid RoomdId) : ICommand;

