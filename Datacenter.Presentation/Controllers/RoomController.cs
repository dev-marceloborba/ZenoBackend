using Datacenter.Application.DatacenterRoom.Commands.CreateDatacenterRoom;
using Datacenter.Application.Rooms.Commands.DeleteRoom;
using Datacenter.Application.Rooms.Commands.UpdateRoom;
using Datacenter.Application.Rooms.Queries.ListRooms;
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

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> ListRooms(CancellationToken cancellationToken)
    {
        var query = new ListRoomsQuery();
        var response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRoom(
        [FromBody] UpdateRoomCommand command, 
        CancellationToken cancellationToken
        )
    {
        var result = await Sender.Send(command, cancellationToken );

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRoom(
        [FromQuery] Guid roomId,
        CancellationToken cancellationToken
        )
    {
        var command = new DeleteRoomCommand(roomId);
        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
