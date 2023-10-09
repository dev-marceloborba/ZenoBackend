using Datacenter.Domain.Entities;

namespace Datacenter.Domain.Repositories;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetAllDatacenterRoomAsync(CancellationToken cancellationToken = default);
    Task<Room?> GetByIdDatacenterRoomAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Room room);
}
