using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;


namespace SChainIntro_MVC.Data.Repositories;


public class Repository<TEntity>(AppDbContext dbContext)
    : IRepository<TEntity> where TEntity : Base
{
    protected readonly AppDbContext _dbContext = dbContext;
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    
    public async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.ID == id);
        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    { 
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}