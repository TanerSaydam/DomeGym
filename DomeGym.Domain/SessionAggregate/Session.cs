using DomeGym.Domain.Common;
using DomeGym.Domain.Common.Interfaces;
using DomeGym.Domain.Common.ValueObjects;
using DomeGym.Domain.ParticipantAggregate;
using ErrorOr;

namespace DomeGym.Domain.SessionAggregate;
public class Session: AggregateRoot
{
    private readonly Guid _trainerId;
    private readonly List<Reservation> _reservations = new();
    private readonly int _maxParticipants;

    public DateOnly Date { get; }

    public TimeRange Time { get; }
    public Session(
        DateOnly date,
        TimeRange time,
        int maxParticipants,
        Guid trainerId,
        Guid? id = null): base(id ?? Guid.NewGuid())
    {
        Date = date;
        Time = time;
        _maxParticipants = maxParticipants;
        _trainerId = trainerId;       
    }

    public ErrorOr<Success> CancelResevation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
            return SessionErrors.CannotCancelReservationTooCloseToSession;

        var reservation = _reservations.Find(reservation => reservation.ParticipantId == participant.Id);
        if (reservation is null)
        {
            return Error.NotFound(description: "Participant not found");
        }

        _reservations.Remove(reservation);

        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime utcNow)
    {
        const int MinHour = 24;
        return (Date.ToDateTime(Time.Start) - utcNow).TotalHours < MinHour;
    }

    public ErrorOr<Success> ReserveSpot(Participant participant)
    {
        if (_reservations.Count >= _maxParticipants)
        {
            return SessionErrors.CannotHaveMoreReservationThanParticipants;
        }

        var reservation = _reservations.Find(reservation => reservation.ParticipantId == participant.Id);
        if (reservation is null)
        {
            return Error.Conflict(description: "Participant cannot reserve twice to the same session");
        }

        reservation = new Reservation(participant.Id);

        _reservations.Add(reservation);

        return Result.Success;
    }
}
