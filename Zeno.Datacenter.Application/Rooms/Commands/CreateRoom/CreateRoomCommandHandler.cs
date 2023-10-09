using Datacenter.Application.Abstractions;
using Datacenter.Domain.Entities;
using Datacenter.Domain.Repositories;
using Datacenter.Domain.Shared;

namespace Datacenter.Application.DatacenterRoom.Commands.CreateDatacenterRoom;

internal sealed class CreateRoomCommandHandler : ICommandHandler<CreateRoomCommand>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoomCommandHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var datacenterRoom = new Room(Guid.NewGuid(), request.Name, request.MaxRacks);

        _roomRepository.Add(datacenterRoom);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
