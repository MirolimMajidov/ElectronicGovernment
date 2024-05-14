using ElectronicGovernment.API.Models;

namespace ElectronicGovernment.API.Infrastructure;

public interface IEGContext
{
    public IQueryable<T> GetEntities<T>() where T : BaseEntity;
}
