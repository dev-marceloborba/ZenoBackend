using Datacenter.Application.Abstractions;
using Datacenter.Domain.Repositories;
using Datacenter.Domain.Shared;

namespace Datacenter.Application.Rooms.Queries.ListRooms;

internal sealed class ListRoomsQueryHandler : IQueryHandler<ListRoomsQuery, IEnumerable<RoomResponse>>
{
    private readonly IRoomRepository _roomRepository;

    public ListRoomsQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<Result<IEnumerable<RoomResponse>>> Handle(ListRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.GetAllDatacenterRoomAsync(cancellationToken);

        return rooms
            .Select(r => new RoomResponse(r.Id, r.Name))
            .ToList();
    }
}
