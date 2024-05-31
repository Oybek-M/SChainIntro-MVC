using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.Data.Interfaces;

public interface IRepository<TEntity> where TEntity : Base
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}