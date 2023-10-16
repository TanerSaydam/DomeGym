using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUtils.Common;
using DomeGym.Domain.UnitTests.TestUtils.Sessions;
using DomeGym.Domain.UnitTests.TestUtils.Trainers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeGym.Domain.UnitTests;
public class TrainerTests
{
    [Theory]
    [InlineData(1, 3, 1, 3)]
    [InlineData(1, 3, 2, 3)]
    [InlineData(1, 3, 2, 4)]
    [InlineData(1, 3, 0, 2)]
    public void AddSessionToSchedule_WhenSessionOverlapsWithAnotherSession_ShouldFail(
        int startHourSessions1,
        int endHourSessions1,
        int startHourSessions2,
        int endHourSessions2)
    {
        // Arrange
        var trainer = TrainerFactory.CreateTrainer();

        var session1 = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: TimeRangeFactory.CreateFromHours(startHourSessions1, endHourSessions1),
            id: Guid.NewGuid());

        var session2 = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: TimeRangeFactory.CreateFromHours(startHourSessions2, endHourSessions2),
            id: Guid.NewGuid());

        // Act
        var addSession1Result = trainer.AddSessionToSchedule(session1);
        var addSession2Result = trainer.AddSessionToSchedule(session2);

        // Assert
        addSession1Result.IsError.Should().BeFalse();

        addSession2Result.IsError.Should().BeTrue();
        addSession2Result.FirstError.Should().Be(TrainerErrors.CannotHaveTwoOrMoreOverlappingSessions);
    }
}
