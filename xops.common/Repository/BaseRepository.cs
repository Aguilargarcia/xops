using System;
using Microsoft.EntityFrameworkCore;
using xops.common.Entities;
using xops.common.Interfaces;

namespace xops.common.Repository;

public class BaseRepository<T> : IRepository<T> where T : Entity
{
    private readonly DbSet<T> _db;
    private readonly DbContext _context;
    public BaseRepository(DbContext context){
        _context = context;
        _db = context.Set<T>();
    }
    public virtual async Task AddAsync(T entity)
    {
        await _db.AddAsync(entity);
        await this.SaveChangesAsync();
    }

    public virtual async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await _db.ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(Guid Id)
    {
        return await _db.FindAsync(Id);
    }

    public async Task<int> RemoveAsync(T entity)
    {
        _db.Remove(entity);
        return await this.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<int> UpdateAsync(T entity)
    {
        _db.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return await this.SaveChangesAsync();
    }
}
