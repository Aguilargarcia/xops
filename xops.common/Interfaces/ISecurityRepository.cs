using System;

namespace xops.common.Interfaces;

public interface ISecurityRepository<T> where T : class
{
    Task<T> GetByIdAsync(string Id);
    Task<IReadOnlyCollection<T>> GetAllAsync();
}
