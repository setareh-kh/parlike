using System.Linq.Expressions;

namespace ParlikeWebApi.Repositories;

public interface IBaseRepository<TEntity>
{
    //Create
    Task InsertAsync(TEntity entity);
    Task Insert(TEntity entity);
    //Read
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
    //Update
    void Update(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> UpdateByIdAsync(int id, TEntity newValue);
    //Delete
    void Delete(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<bool> DeleteByIdAsync(int id);
    Task<int> WhereDeleteAsync(Expression<Func<TEntity, bool>> predicate);
    //Other common operations
    Task<bool> SaveChangesAsync();



}