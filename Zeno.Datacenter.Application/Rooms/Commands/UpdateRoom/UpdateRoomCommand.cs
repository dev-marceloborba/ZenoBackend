using Datacenter.Application.Abstractions;
using Datacenter.Domain.Entities;

namespace Datacenter.Application.Rooms.Commands.UpdateRoom;

public sealed record UpdateRoomCommand(Guid RoomId, Room Room) : ICommand;

