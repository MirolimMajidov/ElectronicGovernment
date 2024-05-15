using ElectronicGovernment.API.Models;

namespace ElectronicGovernment.API.Infrastructure;

public interface IEGContext
{
    public static Guid GlobalId { get; set; } = Guid.Parse("2A720891-3E68-4538-BF8F-51B6B5C2067C");
    public IQueryable<T> GetEntities<T>() where T : BaseEntity;
}
