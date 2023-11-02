using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datacenter.Application.Rooms.Queries.ListRooms;

public sealed record RoomResponse(Guid Id, string Name);

