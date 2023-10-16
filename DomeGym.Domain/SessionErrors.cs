using ErrorOr;

namespace DomeGym.Domain;
public static class SessionErrors
{
    public readonly static Error CannotHaveMoreReservationThanParticipants = Error.Validation(
        code: "Session.CannotHaveMoreReservationThanParticipants",
        description: "Cannot have more resevation than participants");

    public readonly static Error CannotCancelReservationTooCloseToSession = Error.Validation(
        code: "Session.CannotCancelReservationTooCloseToSession",
        description: "Cannot cancel reservation too close to session");    
}
