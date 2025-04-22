using System;
using xops.common.Entities;

namespace xops.common.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<int> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> RemoveAsync(T entity);
    Task<T> GetByIdAsync(Guid Id);
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<int> SaveChangesAsync();


}
