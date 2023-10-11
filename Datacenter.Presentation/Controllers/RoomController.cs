using Datacenter.Application.DatacenterRoom.Commands.CreateDatacenterRoom;
using Datacenter.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Datacenter.Presentation.Controllers;

[Route("api/rooms")]
public sealed class RoomController : ApiController
{
    public RoomController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom(
        [FromBody] CreateRoomCommand command,
        CancellationToken cancellationToken
        )
    {
        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest();
    }
}
