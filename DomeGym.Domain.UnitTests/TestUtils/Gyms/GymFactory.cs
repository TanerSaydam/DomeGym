﻿using DomeGym.Domain.GymAggregate;
using DomeGym.Domain.UnitTests.TestConstants;

namespace DomeGym.Domain.UnitTests.TestUtils.Gyms;
public static class GymFactory
{
    public static Gym CreateGym(
        int maxRooms = Constants.Subscriptions.MaxRoomsFreeTier,
        Guid? id = null)
    {
        return new Gym(
            maxRooms,
            subscriptionId: Constants.Subscriptions.Id,
            id: id ?? Constants.Gym.Id);
    }
}
