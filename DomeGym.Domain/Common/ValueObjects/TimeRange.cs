using DomeGym.Domain.Common;
using ErrorOr;
using Throw;

namespace DomeGym.Domain.Common.ValueObjects;
public class TimeRange : ValueObject
{
    public TimeRange(TimeOnly start, TimeOnly end)
    {
        Start = start.Throw().IfGreaterThanOrEqualTo(end);
        End = end;
    }

    public TimeOnly Start { get; init; }
    public TimeOnly End { get; init; }

    public static ErrorOr<TimeRange> FromDateTimes(DateTime start, DateTime end)
    {
        if(start.Date != end.Date)
        {
            return Error.Validation(description: "Start and end date must be the same");
        }

        if(start >= end)
        {
            return Error.Validation(description: "End time must be greater then the start");
        }

        return new TimeRange(TimeOnly.FromDateTime(start), TimeOnly.FromDateTime(end));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }

    public bool OverlapsWith(TimeRange other)
    {
        if (Start >= other.End) return false;
        if (other.Start >= End) return false;
        return true;
    }
}
