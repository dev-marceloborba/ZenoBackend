using Datacenter.Application.Abstractions;

namespace Datacenter.Application.Rooms.Queries.ListRooms;

public sealed record ListRoomsQuery(): IQuery<IEnumerable<RoomResponse>>;
