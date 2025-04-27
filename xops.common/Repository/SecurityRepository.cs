using System;
using Microsoft.EntityFrameworkCore;
using xops.common.Interfaces;

namespace xops.common.Repository;

public class SecurityRepository<T> : ISecurityRepository<T> where T : class
{
    private readonly DbContext _context;
    public SecurityRepository(DbContext context){
        _context = context;
    }
    public async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync(); 
    }

    public async Task<T> GetByIdAsync(string Id)
    {
        return await _context.Set<T>().FindAsync(Id);
    }
}