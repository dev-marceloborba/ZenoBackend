using Datacenter.Domain.Entities;

namespace Datacenter.Domain.Repositories;

public interface IDatacenterRoomRepository
{
    Task<IEnumerable<DatacenterRoom>> GetAllDatacenterRoomAsync(CancellationToken cancellationToken = default);
    Task<DatacenterRoom?> GetByIdDatacenterRoomAsync(Guid id, CancellationToken cancellationToken = default);
    void AddDatacenterRoom(DatacenterRoom datacenterRoom);
}
