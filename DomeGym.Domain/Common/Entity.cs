namespace DomeGym.Domain.Common;
public abstract class Entity
{
    public Guid Id { get; }

    protected Entity(Guid ıd)
    {
        Id = ıd;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        return ((Entity)obj).Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
