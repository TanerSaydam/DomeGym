﻿using DomeGym.Domain.RoomAggergate;
using DomeGym.Domain.UnitTests.TestConstants;

namespace DomeGym.Domain.UnitTests.TestUtils.Rooms;
public static class RoomFactory
{
    public static Room CreateRoom(
        int maxDailySessions = Constants.Room.MaxDailySessions,
        Guid? gymId = null,
        Guid? id = null)
    {
        return new Room(
            maxDailySessions: maxDailySessions,
            gymId: gymId ?? Guid.NewGuid(),
            id: id ?? Guid.NewGuid());
    }
}
