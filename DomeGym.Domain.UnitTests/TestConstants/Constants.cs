using DomeGym.Domain.Common.ValueObjects;
using DomeGym.Domain.SubscriptionAggregate;

namespace DomeGym.Domain.UnitTests.TestConstants;
public static class Constants
{
    public static class Session
    {
        public static readonly Guid Id = Guid.NewGuid();
        public const int MaxParticipants = 10;
        public static readonly DateOnly Date = DateOnly.FromDateTime(DateTime.Now);
        public static readonly TimeRange Time = new(
            TimeOnly.MinValue.AddHours(8),
            TimeOnly.MinValue.AddHours(9));
    }

    public static class Trainer
    {
        public static readonly Guid Id = Guid.NewGuid();
    }

    public static class Participant
    {
        public static readonly Guid Id = Guid.NewGuid();
    }
    
    public static class User
    {
        public static readonly Guid Id = Guid.NewGuid();
    }

    public static class Admin
    {
        public static readonly Guid Id = Guid.NewGuid();
    }

    public static class Gym
    {
        public static readonly Guid Id = Guid.NewGuid();
    }

    public static class Room
    {
        public static readonly Guid Id = Guid.NewGuid();
        public const int MaxDailySessions = Subscriptions.MaxDailySessionsFreeTier;
    }

    public static class Subscriptions
    {
        public static readonly SubscriptionType DefaultSubscriptionType = SubscriptionType.Free;
        public static readonly Guid Id = Guid.NewGuid();
        public const int MaxDailySessionsFreeTier = 4;
        public const int MaxRoomsFreeTier = 1;
        public const int MaxGymsFreeTier = 1;
    }
}
