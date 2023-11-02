using Datacenter.Application.Abstractions;
using Datacenter.Domain.Entities;
using Datacenter.Domain.Repositories;
using Datacenter.Domain.Shared;
using Mapster;

namespace Datacenter.Application.Rooms.Commands.UpdateRoom;

internal sealed class UpdateRoomCommandHandler : ICommandHandler<UpdateRoomCommand>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoomCommandHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = request.Adapt<Room>();
        _roomRepository.Update(room);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
