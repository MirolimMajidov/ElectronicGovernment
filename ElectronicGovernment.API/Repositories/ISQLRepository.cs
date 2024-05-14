using ElectronicGovernment.API.Infrastructure;
using ElectronicGovernment.API.Models;

namespace ElectronicGovernment.API.Repositories;
public interface ISQLRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    Task<T> GetById(Guid id);
    T TryCreate(T item, out string message);
    bool TryUpdate(T item, out string message);
    bool TryDelete(Guid id, out string message);
    IEGContext GetContext();
}

