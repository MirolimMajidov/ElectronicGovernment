namespace ElectronicGovernment.API.Models;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public override string ToString()
    {
        return $"Id:{Id} ({GetType().Name})";
    }
}
