using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ParlikeWebApi.Models;

namespace ParlikeWebApi.Repositories.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, ISqlEntity
{
    protected readonly SqlContext SqlContext;
    protected BaseRepository(SqlContext sqlContext)
    {
        SqlContext = sqlContext;
    }
    //Create
    public async Task InsertAsync(TEntity entity)
    {
        await SqlContext.Set<TEntity>().AddAsync(entity);
        await SqlContext.SaveChangesAsync();
    }
    public async Task Insert(TEntity entity)
    {
        await SqlContext.Set<TEntity>().AddAsync(entity);
    }
    //Read
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await SqlContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await SqlContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await SqlContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await SqlContext.Set<TEntity>().Where(predicate).ToListAsync();
    }
    //Update 
    public void Update(TEntity entity)
    {
        SqlContext.Set<TEntity>().Update(entity);
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        Update(entity);
        await SqlContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateByIdAsync(int id, TEntity newValue)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            await UpdateAsync(newValue);
            return true;
        }
        else return false;
    }
    //Delete
    public void Delete(TEntity entity)
    {
        SqlContext.Set<TEntity>().Remove(entity);
    }
    public async Task<bool> DeleteAsync(TEntity entity)
    {
        SqlContext.Set<TEntity>().Remove(entity);
        await SqlContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            await DeleteAsync(entity);
            return true;
        }
        else return false;
    }
    public async Task<int> WhereDeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entities = await SqlContext.Set<TEntity>().Where(predicate).ToListAsync();
        SqlContext.Set<TEntity>().RemoveRange(entities);
        return await SqlContext.SaveChangesAsync();
    }
    //Other common operations
    public async Task<bool> SaveChangesAsync() => await SqlContext.SaveChangesAsync() > 0;
}