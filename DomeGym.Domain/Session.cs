using ErrorOr;

namespace DomeGym.Domain;
public class Session
{    
    private readonly Guid _trainerId;
    private readonly List<Guid> _participantIds = new();
    private readonly int _maxParticipants;

    public Guid Id { get; }

    public DateOnly Date { get; }

    public TimeRange Time { get; }
    public Session(
        DateOnly date,
        TimeRange time,
        int maxParticipants,
        Guid trainerId,
        Guid? id = null)
    {
        Date = date;
        Time = time;        
        _maxParticipants = maxParticipants;
        _trainerId = trainerId;
        Id = id ?? Guid.NewGuid();
    }

    public ErrorOr<Success> CancelResevation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
            return SessionErrors.CannotCancelReservationTooCloseToSession;

        if (!_participantIds.Remove(participant.Id))
        {
            return Error.NotFound(description: "Participant not found");
        }

        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime utcNow)
    {
        const int MinHour = 24;
        return (Date.ToDateTime(Time.Start) - utcNow).TotalHours < MinHour;
    }

    public ErrorOr<Success> ReserveSpot(Participant participant1)
    {
        if (_participantIds.Count >= _maxParticipants)
        {
            return SessionErrors.CannotHaveMoreReservationThanParticipants;
        }
        
        if(_participantIds.Contains(participant1.Id))
        {
            return Error.Conflict(description: "Participant cannot reserve twice to the same session");
        }

        _participantIds.Add(participant1.Id);

        return Result.Success;
    }
}
