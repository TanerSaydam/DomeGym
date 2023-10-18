namespace DomeGym.Domain.Common;
public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Guid ıd) : base(ıd)
    {
    }
}
