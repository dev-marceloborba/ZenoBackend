using Datacenter.Domain.Entities;
using Datacenter.Domain.Repositories;

namespace Datacenter.Persistence.Repository;

internal sealed class RoomRepostiory : IRoomRepository
{
    public void Add(Room room)
    {
        throw new NotImplementedException();
    }

    public void Delete(Room room)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Room>> GetAllDatacenterRoomAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Room?> GetByIdDatacenterRoomAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Update(Room room)
    {
        throw new NotImplementedException();
    }
}
