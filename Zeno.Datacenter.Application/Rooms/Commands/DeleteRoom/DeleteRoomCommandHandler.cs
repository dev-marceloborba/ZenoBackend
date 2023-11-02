using Datacenter.Application.Abstractions;
using Datacenter.Domain.Repositories;
using Datacenter.Domain.Shared;

namespace Datacenter.Application.Rooms.Commands.DeleteRoom;

internal sealed class DeleteRoomCommandHandler : ICommandHandler<DeleteRoomCommand>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoomCommandHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdDatacenterRoomAsync(request.RoomdId, cancellationToken);

        if (room is null)
        {
            return Result.Failure(new Error("Room.NotFound", "Sala nao encontrada"));
        }

        _roomRepository.Delete(room);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
