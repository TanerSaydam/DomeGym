using DomeGym.Domain.GymAggregate;
using DomeGym.Domain.UnitTests.TestUtils.Gyms;
using DomeGym.Domain.UnitTests.TestUtils.Rooms;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests;
public class GymTests
{
    [Fact]
    public void AddRoom_WhenMoreThanSubscriptionAllows_ShouldFail()
    {
        // Arrange
        var gym = GymFactory.CreateGym(maxRooms: 1);
        var room1 = RoomFactory.CreateRoom(id: Guid.NewGuid());
        var room2 = RoomFactory.CreateRoom(id: Guid.NewGuid());

        // Act
        var addRoomResult1 = gym.AddRoom(room1);
        var addRoomResult2 = gym.AddRoom(room2);

        // Assert
        addRoomResult1.IsError.Should().BeFalse();

        addRoomResult2.IsError.Should().BeTrue();
        addRoomResult2.FirstError.Should().Be(GymErrors.CannotHaveMoreRoomsThanSubscriptionAllows);
    }
}
